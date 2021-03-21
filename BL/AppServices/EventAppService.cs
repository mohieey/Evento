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
    public class EventAppService : BaseAppService
    {
        public List<EventViewModel> GetAllEvents()
        {
            return Mapper.Map<List<EventViewModel>>(TheUnitOfWork.Event.GetAllEvents());
        }

        public EventViewModel GetEventById(int id)
        {
            return Mapper.Map<EventViewModel>(TheUnitOfWork.Event.GetEventById(id));
        }

        //public EventViewModel CreateEvent(EventViewModel eventViewModel)
        //{
        //    Event newEvent = Mapper.Map<Event>(eventViewModel);
        //    return Mapper.Map<EventViewModel>(TheUnitOfWork.Event.InsertEvent(newEvent));
        //}

        //public List<OrderViewModel> GetOrdersByClientId(string id)
        //{
        //    TheUnitOfWork.Order.
        //    return Mapper.Map<OrderViewModel>(TheUnitOfWork.Order.GetOrdersByClientId(id));
        //}

        public bool SaveNewEvent(EventViewModel eventViewModel)
        {
            bool result = false;
            var @event = Mapper.Map<Event>(eventViewModel);

            TheUnitOfWork.Event.InsertEvent(@event);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public void SaveEventChanges(EventViewModel eventViewModel)
        {

            var @event = TheUnitOfWork.Event.GetEventById(eventViewModel.ID);
            @event.Name = eventViewModel.Name;
            @event.location = eventViewModel.location;
            @event.TotalAvailableTickets = eventViewModel.TotalAvailableTickets;
            @event.description = eventViewModel.description;
            @event.age = eventViewModel.age;
            @event.category = eventViewModel.category;
            @event.isCanceled = eventViewModel.isCanceled;

            TheUnitOfWork.Commit();
        }


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
