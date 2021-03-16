using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace DAL
{

    public class ApplicationUserManager : UserManager<ApplicationIdentityUser>
    {
        public ApplicationUserManager() : base(new ApplicationUserStore())
        {

        }
        public ApplicationUserManager(DbContext db) : base(new ApplicationUserStore(db))
        {

        }
    }



}
