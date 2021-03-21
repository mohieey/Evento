using BL.Bases;
using BL.ViewModels;
using DAL;
using DAL.User;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class AccountAppService : BaseAppService
    {
        public ApplicationIdentityUser Find(string name, string password)
        {
            return TheUnitOfWork.Account.Find(name, password);
        }

        public IdentityResult Register(RegisterViewModel user, bool isHost, bool isAdmin)
        {
            ApplicationIdentityUser identityUser =
                Mapper.Map<RegisterViewModel, ApplicationIdentityUser>(user);

            IdentityResult identityResult = TheUnitOfWork.Account.Register(identityUser);
            if (!isAdmin)
            {
                if (isHost)
                {
                    var host = Mapper.Map<ApplicationIdentityUser, HostUser>(identityUser);
                    TheUnitOfWork.Host.AddAsAHost(host);
                }
                else
                {
                    var client = Mapper.Map<ApplicationIdentityUser, ClientUser>(identityUser);
                    TheUnitOfWork.Client.AddAsAClient(client);
                }
            }
            return identityResult;
        }
        public IdentityResult AssignToRole(string userid, string rolename)
        {
            return TheUnitOfWork.Account.AssignToRole(userid, rolename);
        }

        public ApplicationIdentityUser GetUserById(string id)
        {
            return TheUnitOfWork.Account.GetUserById(id);
        }
    }
}
