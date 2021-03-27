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
        public List<Order> GetOrders()
        {
            return TheUnitOfWork.Order.GetAllOrders();
        }

        public List<OrderViewModel> GetAllOrder()
        {
            return Mapper.Map<List<OrderViewModel>>(TheUnitOfWork.Order.GetAllOrders());
        }

        public OrderViewModel GetOrderById(int id)
        {
            return Mapper.Map<OrderViewModel>(TheUnitOfWork.Order.GetOrderById(id));
        }

        public Order InsertOrder(string userId, int totalPrice)
        {
            //ClientAccountRepository clientRepo = new ClientAccountRepository(ApplicationDBContext.applicationDBContext);
            //ClientUser client = clientRepo.GetClientById(id);
            Order newOrder = new Order { clientId = userId, totalPrice = totalPrice };

            TheUnitOfWork.Order.Insert(newOrder);

            TheUnitOfWork.Commit();
            return newOrder;
        }

        public Order TransferTicketsToOrder(Order newOrder, List<Ticket> ticketList)
        {
            foreach (var ticket in ticketList)
            {
                TheUnitOfWork.OrderTicket.Insert(
                    new OrderTicket
                    {
                        orderId = newOrder.ID,
                        ticketId = ticket.ID
                    });
            }
            TheUnitOfWork.Commit();

            var shoppingCart = TheUnitOfWork.ShoppingCart.GetShoppingCartByUserId(newOrder.clientId);

            TheUnitOfWork.ShoppingCartTicket.ClearShoppingCart(shoppingCart.ID);
            
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
