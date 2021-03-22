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
        public List<TicketViewModel> GetAllTickets()
        {
            return Mapper.Map<List<TicketViewModel>>(TheUnitOfWork.Ticket.GetAllTickets());
        }
        public TicketViewModel CreateTicket(TicketViewModel ticketViewModel)
        {
            Ticket newTicket = Mapper.Map<Ticket>(ticketViewModel);
            return Mapper.Map<TicketViewModel>(TheUnitOfWork.Ticket.InsertTicket(newTicket));
        }

        public void UpdateTicket(TicketViewModel ticketViewModel)
        {
            Ticket ticket = Mapper.Map<Ticket>(ticketViewModel);
            TheUnitOfWork.Ticket.UpdateTicket(ticket);
        }

        public void DeleteTicket(int id)
        {
            TheUnitOfWork.Ticket.DeleteTicket(id);
        }

        public TicketViewModel CheckTicketExists(TicketViewModel ticketViewModel)
        {
            Ticket ticket = Mapper.Map<Ticket>(ticketViewModel);
            return Mapper.Map<TicketViewModel>(TheUnitOfWork.Ticket.CheckTicketExists(ticket));
        }

        public TicketViewModel GetTicketById(int id)
        {
            return Mapper.Map<TicketViewModel>(TheUnitOfWork.Ticket.GetTicketById(id));
        }
    }
}
