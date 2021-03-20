﻿using BL.Interfaces;
using BL.Repositories;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Bases
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext DbContext { get; set; }

        public UnitOfWork()
        {
            DbContext = ApplicationDBContext.applicationDBContext;
            DbContext.Configuration.LazyLoadingEnabled = false;
        }

        public int Commit()
        {
            return DbContext.SaveChanges();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }

        private OrderRepository order; 
        public OrderRepository Order
        {
            get
            {
                if (order == null)
                    order = new OrderRepository(DbContext);
                return order;
            }
        }

        private AccountRepository account; 
        public AccountRepository Account
        {
            get
            {
                if (account == null)
                    account = new AccountRepository(DbContext);
                return account;
            }
        }

        private RoleRepository role; 
        public RoleRepository Role
        {
            get
            {
                if (role == null)
                    role = new RoleRepository(DbContext);
                return role;
            }
        }

        private TicketRepository ticket; 
        public TicketRepository Ticket
        {
            get
            {
                if (ticket == null)
                    ticket = new TicketRepository(DbContext);
                return ticket;
            }
        }

        private EventRepository @event; 
        public EventRepository Event
        {
            get
            {
                if (@event == null)
                    @event = new EventRepository(DbContext);
                return @event;
            }
        }
    }
}
