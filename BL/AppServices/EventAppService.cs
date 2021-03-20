using BL.Bases;
using BL.ViewModels;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    class EventAppService : BaseAppService
    {
        public List<EventViewModel> GetAllEvents()
        {
            return Mapper.Map<List<EventViewModel>>(TheUnitOfWork.Event.GetAllEvents());
        }

        public EventViewModel GetEventById(int id)
        {
            return Mapper.Map<EventViewModel>(TheUnitOfWork.Event.GetEventById(id));
        }

        public EventViewModel CreateEvent(EventViewModel eventViewModel)
        {
            Event newEvent = Mapper.Map<Event>(eventViewModel);
            return Mapper.Map<EventViewModel>(TheUnitOfWork.Event.InsertEvent(newEvent));
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
