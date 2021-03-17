using BL.Bases;
using DAL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repositories
{
    public class AccountRepository
    {
        ApplicationUserManager manager;

        public AccountRepository(DbContext db)
        {
            manager = new ApplicationUserManager(db);
        }

        public ApplicationIdentityUser Find(string username, string password)
        {
            ApplicationIdentityUser result = manager.Find(username, password);
            return result;
        }

        public IdentityResult Register(ApplicationIdentityUser user)
        {
            IdentityResult result = manager.Create(user, user.PasswordHash);
            return result;
        }

        public IdentityResult AssignToRole(string userid, string rolename)
        {
            IdentityResult result = manager.AddToRole(userid, rolename);
            return result;
        }
    }
}
