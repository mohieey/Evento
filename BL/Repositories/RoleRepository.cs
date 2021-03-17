using DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repositories
{
    class RoleRepository
    {
        ApplicationRoleManager manager;
        public RoleRepository(DbContext db)
        {
            manager = new ApplicationRoleManager(db);
        }

        public IdentityResult Create(string role)
        {
            return manager.Create(new IdentityRole(role));
        }
    }
}
