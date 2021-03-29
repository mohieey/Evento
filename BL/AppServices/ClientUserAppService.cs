using BL.Bases;
using BL.ViewModels;
using DAL;
using DAL.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class ClientUserAppService : BaseAppService
    {
        public List<ClientUserViewModel> GetAllClientUser()
        {
            List<ClientUser> clientUsers = TheUnitOfWork.Client.GetAllClientUser();
            List<ClientUserViewModel> clientUserViews = new List<ClientUserViewModel>();
            foreach (var clientUser in clientUsers)
            {
                clientUserViews.Add(
                    new ClientUserViewModel 
                    { 
                        ID = clientUser.Id,
                        UserName = clientUser.user.UserName,
                        Email = clientUser.user.Email,
                        Age = clientUser.user.age,
                        Address = clientUser.user.address
                    });
            }
            return clientUserViews;
        }

        public ClientUserViewModel GetClientById(string id)
        {
             ClientUser clientUser = TheUnitOfWork.Client.GetClientById(id);
            ClientUserViewModel clientUserVM = new ClientUserViewModel();

            clientUserVM.ID = clientUser.Id;
            clientUserVM.UserName = clientUser.user.UserName;
            clientUserVM.Email = clientUser.user.Email;
            clientUserVM.Age = clientUser.user.age;
            clientUserVM.Address = clientUser.user.address;


            return clientUserVM;
        }

        public void UpdateClientUser(ClientUserViewModel clientUserVM)
        {
            ClientUser clientUser = TheUnitOfWork.Client.GetClientById(clientUserVM.ID);


            clientUser.user.UserName = clientUserVM.UserName;
            clientUser.user.Email = clientUserVM.Email;
            clientUser.user.age = clientUserVM.Age;
            clientUser.user.address = clientUserVM.Address;


            TheUnitOfWork.Client.UpdateClientUser(clientUser);
        }
    }
}
