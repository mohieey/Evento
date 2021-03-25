using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace DAL
{
    
    public class ApplicationUserStore : UserStore<ApplicationIdentityUser>
    {
        public ApplicationUserStore() : base(ApplicationDBContext.applicationDBContext)
        {

        }
        public ApplicationUserStore(DbContext db) : base(db)
        {

        }
    }



}
