using BL.Bases;
using BL.ViewModels;
using DAL.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class HostUserAppService : BaseAppService
    {
        public List<HostUserViewModel> GetAllHostUser()
        {
            List<HostUser> HostUsers = TheUnitOfWork.Host.GetAllHosts();
            List<HostUserViewModel> clientUserViews = new List<HostUserViewModel>();
            foreach (var HostUser in HostUsers)
            {
                clientUserViews.Add(
                    new HostUserViewModel
                    {
                        ID = HostUser.Id,
                        UserName = HostUser.user.UserName,
                        Email = HostUser.user.Email,
                        Age = HostUser.user.age,
                        Address = HostUser.user.address
                    });
            }
            return clientUserViews;
        }

        public HostUserViewModel GetHostById(string id)
        {
            HostUser hostUser = TheUnitOfWork.Host.GetHostById(id);
            HostUserViewModel hostUserVM = new HostUserViewModel();

            hostUserVM.ID = hostUser.Id;
            hostUserVM.UserName = hostUser.user.UserName;
            hostUserVM.Email = hostUser.user.Email;
            hostUserVM.Age = hostUser.user.age;
            hostUserVM.Address = hostUser.user.address;

            return hostUserVM;
        }

        public void UpdateHostUser(HostUserViewModel hostUserVM)
        {
            HostUser hostUser = new HostUser();

            hostUser.Id = hostUserVM.ID;
            hostUser.user.UserName = hostUserVM.UserName;
            hostUser.user.Email = hostUserVM.Email;
            hostUser.user.age = hostUserVM.Age;
            hostUser.user.address = hostUserVM.Address;

            TheUnitOfWork.Host.UpdateHostUser(hostUser);
        }

    }
}
