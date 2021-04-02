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

        public EventViewModel EditEvent(EventViewModel eventViewModel)
        {
            var @event = TheUnitOfWork.Event.GetEventById(eventViewModel.ID);

            //Mapper.Map(eventViewModel, @event);


            @event.Name = eventViewModel.Name;
            @event.location = eventViewModel.location;
            @event.TotalAvailableTickets = eventViewModel.TotalAvailableTickets;
            @event.description = eventViewModel.description;
            @event.age = eventViewModel.age;
            @event.price = eventViewModel.price;
            @event.category = eventViewModel.category;
            @event.image = eventViewModel.image;

            TheUnitOfWork.Event.UpdateEvent(@event);
            TheUnitOfWork.Commit();
            return eventViewModel;
        }

        public Event SaveNewEvent(EventViewModel eventViewModel)
        {
            bool result = false;
            var @event = Mapper.Map<Event>(eventViewModel);

            Event e =  TheUnitOfWork.Event.InsertEvent(@event);
            result = TheUnitOfWork.Commit() > new int();

            return e;
        }





        public void DeleteEvent(Event @event)
        {
            TheUnitOfWork.Event.Delete(@event);
            TheUnitOfWork.Commit();
        }
    }
}
