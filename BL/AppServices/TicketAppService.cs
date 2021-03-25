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
    public class TicketAppService : BaseAppService
    {
        public List<Ticket> GetAllTickets()
        {
            return Mapper.Map<List<Ticket>>(TheUnitOfWork.Ticket.GetAllTickets());
        }
        public Ticket CreateTicket(Event @event)
        {
            Ticket newTicket = new Ticket() { eventId = @event.ID };
            return newTicket;
        }

        public void UpdateTicket(Ticket Ticket)
        {
            Ticket ticket = Mapper.Map<Ticket>(Ticket);
            TheUnitOfWork.Ticket.UpdateTicket(ticket);
        }

        public void DeleteTicket(int id)
        {
            TheUnitOfWork.Ticket.DeleteTicket(id);
        }

        public Ticket CheckTicketExists(Ticket Ticket)
        {
            Ticket ticket = Mapper.Map<Ticket>(Ticket);
            return Mapper.Map<Ticket>(TheUnitOfWork.Ticket.CheckTicketExists(ticket));
        }

        public Ticket GetTicketById(int id)
        {
            return Mapper.Map<Ticket>(TheUnitOfWork.Ticket.GetTicketById(id));
        }
    }
}
