using BL.Bases;
using BL.Repositories;
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
    public class OrderAppService : BaseAppService
    {
        public List<OrderViewModel> GetAllOrder()
        {
            return Mapper.Map<List<OrderViewModel>>(TheUnitOfWork.Order.GetAllOrders());
        }

        public OrderViewModel GetOrderById(int id)
        {
            return Mapper.Map<OrderViewModel>(TheUnitOfWork.Order.GetOrderById(id));
        }

        public Order InsertOrder(string id)
        {
            ClientAccountRepository clientRepo = new ClientAccountRepository(ApplicationDBContext.applicationDBContext);
            ClientUser client = clientRepo.GetClientById(id);

            Order newOrder = new Order { clientId = client.Id };

            TheUnitOfWork.Order.Insert(newOrder);

            TheUnitOfWork.Commit();
            return newOrder;
        }

        //public List<OrderViewModel> GetOrdersByClientId(string id)
        //{
        //    TheUnitOfWork.Order.
        //    return Mapper.Map<OrderViewModel>(TheUnitOfWork.Order.GetOrdersByClientId(id));
        //}

        //public bool SaveNewOrder(OrderViewModel orderViewModel)
        //{
        //    bool result = false;
        //    var order = Mapper.Map<Order>(orderViewModel);
        //    if (TheUnitOfWork.Order.Insert(order))
        //    {
        //        result = TheUnitOfWork.Commit() > new int();
        //    }
        //    return result;
        //}


        //public bool CheckOutOrder(int id)
        //{
        //    bool result = false;

        //    TheUnitOfWork.Order.Delete(id);
        //    result = TheUnitOfWork.Commit() > new int();

        //    return result;
        //}

        //GetOrderPice
        //GetNumberOfTicketsInOrder
    }
}
