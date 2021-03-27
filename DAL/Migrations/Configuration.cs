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

            //User For Unit Testing
            var testUser = manager.Find("TestUser", "TestUser");
            if (testUser == null)
            {
                ApplicationIdentityUser user =
                    new ApplicationIdentityUser()
                    {
                        UserName = "TestUser",
                        PasswordHash = "TestUser",
                    };

                user.PasswordHash = manager.PasswordHasher.HashPassword(user.PasswordHash);
                manager.Create(user);
                manager.AddToRole(user.Id, "User");

                ApplicationIdentityUser registeredUser = manager.Find("TestUser", "TestUser");
                context.ClientUsers.Add(new User.ClientUser { Id = registeredUser.Id });
                context.ShoppingCarts.Add(new ShoppingCart { ClientId = registeredUser.Id });
                context.SaveChanges();
            }

            //Host For Unit Testing
            var testHost = manager.Find("TestHost", "TestHost");
            if (testHost == null)
            {
                ApplicationIdentityUser user =
                    new ApplicationIdentityUser()
                    {
                        UserName = "TestHost",
                        PasswordHash = "TestHost",
                    };

                user.PasswordHash = manager.PasswordHasher.HashPassword(user.PasswordHash);
                manager.Create(user);
                manager.AddToRole(user.Id, "Host");
                ApplicationIdentityUser registeredUser = manager.Find("TestHost", "TestHost");

                context.HostUsers.Add(new User.HostUser { Id = registeredUser.Id });
                context.SaveChanges();
            }






            //AccountAppService accountAppService = new AccountAppService();
            //shoppingCartAppService = new ShoppingCartAppService();


            //RegisterViewModel newUser = new RegisterViewModel
            //{
            //    UserName = "NewUserForTesting",
            //    Email = "test@test.com",
            //    PasswordHash = "123456",
            //    ConfirmPassword = "123456",
            //    age = Enum_Age.Under16,
            //    SSN = "123456789"
            //};

            //IdentityResult result = accountAppService.Register(newUser, false, false);
            //ApplicationIdentityUser registeredUser = accountAppService.Find(newUser.UserName, newUser.PasswordHash);
            //accountAppService.AssignToRole(registeredUser.Id, "User");
            //shoppingCartAppService.Insert(registeredUser.Id);
        }
    }
}
