﻿using DAL.User;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace DAL
{


    public class ApplicationDBContext : IdentityDbContext<ApplicationIdentityUser>
    {
        private static ApplicationDBContext _applicationDBContext = null;
      
        public static ApplicationDBContext applicationDBContext
        {
            get
            {
                if (_applicationDBContext == null)
                {
                    _applicationDBContext = new ApplicationDBContext();
                }
                return _applicationDBContext;
            }
        }

        public ApplicationDBContext() : base("name = cs")
        {

        }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<HostUser> HostUsers { get; set; }
        public virtual DbSet<ClientUser> ClientUsers { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<ShoppingCartTicket> ShoppingCartTickets { get; set; }

    }
}
