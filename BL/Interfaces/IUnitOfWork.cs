using BL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        AccountRepository Account { get; }
        RoleRepository Role { get; }
        OrderRepository Order { get; }
        EventRepository Event { get; }
        TicketRepository Ticket { get; }
        HostAccountRepository Host { get; }
        ClientAccountRepository Client { get; }
        ShoppingCartRepository ShoppingCart { get; }
        ShoppingCartTicketsRepository ShoppingCartTicket { get; }
        OrderTicketRepository OrderTicket { get; }


        int Commit();
    }
}
