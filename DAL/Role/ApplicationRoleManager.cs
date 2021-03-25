using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{

    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager()
            : base(new RoleStore<IdentityRole>( ApplicationDBContext.applicationDBContext))
        {

        }
        public ApplicationRoleManager(DbContext db)
            : base(new RoleStore<IdentityRole>(db))
        {

        }
    }



}
