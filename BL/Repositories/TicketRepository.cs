using BL.Bases;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repositories
{
    public class TicketRepository : BaseRepository<Ticket>
    {
        private DbContext _DbContext;

        public TicketRepository(DbContext DbContext) : base(DbContext)
        {
            this._DbContext = DbContext;
        }

        public List<Ticket> GetAllTickets()
        {
            return GetAll().ToList();
        }

        public Ticket InsertTicket(Ticket ticket)
        {
            return Insert(ticket);
        }

        public void UpdateTicket(Ticket ticket)
        {
            Update(ticket);
        }

        public void DeleteTicket(int id)
        {
            Delete(id);
        }

        public bool CheckTicketExists(Ticket ticket)
        {
            return GetAny(t => t.ID == ticket.ID);
        }

        public Ticket GetTicketById(int id)
        {
            return GetFirstOrDefault(t => t.ID == id);
        }
    }
}
