namespace DAL.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.ApplicationDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.ApplicationDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            ApplicationRoleManager roleManager = new ApplicationRoleManager(context);
            roleManager.Create(new IdentityRole("Admin"));
            roleManager.Create(new IdentityRole("User"));
            roleManager.Create(new IdentityRole("Host"));


            ApplicationUserManager manager = new ApplicationUserManager(context);

            var admin = manager.Find("admin", "admin");
            if(admin == null)
            {
                ApplicationIdentityUser user =
                    new ApplicationIdentityUser()
                    {
                        UserName = "admin",
                        PasswordHash = "admin",
                    };

                user.PasswordHash = manager.PasswordHasher.HashPassword(user.PasswordHash);
                manager.Create(user);
                manager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
