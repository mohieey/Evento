using BL.Bases;
using BL.ViewModels;
using DAL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    class AccountAppService : BaseAppService
    {
        public ApplicationIdentityUser Find(string name, string password)
        {
            return TheUnitOfWork.Account.Find(name, password);
        }

        public IdentityResult Register(RegisterViewModel user)
        {
            ApplicationIdentityUser identityUser =
                Mapper.Map<RegisterViewModel, ApplicationIdentityUser>(user);
            return TheUnitOfWork.Account.Register(identityUser);

        }
        public IdentityResult AssignToRole(string userid, string rolename)
        {
            return TheUnitOfWork.Account.AssignToRole(userid, rolename);
        }
    }
}
