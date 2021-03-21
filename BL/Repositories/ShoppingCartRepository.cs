using AutoMapper;
using BL.Bases;
using DAL;
using DAL.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repositories
{
    public class ShoppingCartRepository : BaseRepository<ShoppingCart>
    {
        private DbContext _DbContext;

        public ShoppingCartRepository(DbContext DbContext) : base(DbContext)
        {
            this._DbContext = DbContext;
        }

        public ShoppingCart GetShoppingCartByUserId(string Id)
        {
            ClientAccountRepository clientRepo = new ClientAccountRepository(_DbContext);
            ClientUser client = clientRepo.GetClientById(Id);
            return client.shoppingCart;
        }

        //public Ticket InsertTicket(Ticket ticket)
        //{
        //    return Insert(ticket);
        //}

        //public void UpdateTicket(Ticket ticket)
        //{
        //    Update(ticket);
        //}

        //public void DeleteTicket(int id)
        //{
        //    Delete(id);
        //}

        //public bool CheckTicketExists(Ticket ticket)
        //{
        //    return GetAny(t => t.ID == ticket.ID);
        //}

        //public Ticket GetTicketById(int id)
        //{
        //    return GetFirstOrDefault(t => t.ID == id);
        //}
    }
}
