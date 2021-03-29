using BL.Bases;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class ShoppingCartAppService: BaseAppService
    {
        public ShoppingCart GetShoppingCartByUserId(string userId)
        {
            return TheUnitOfWork.ShoppingCart.GetShoppingCartByUserId(userId);
        }

        public List<ShoppingCartTicket> GetShoppingCartTicketsByUserId(string userId)
        {
            ShoppingCart shoppingCart = GetShoppingCartByUserId(userId);

            return TheUnitOfWork.ShoppingCartTicket
                    .GetWhere(sct => sct.shoppingCartId == shoppingCart.ID)
                    .Include(sct => sct.ticket)
                    .Include(sct => sct.ticket.Event)
                    .ToList();
        }
        public List<Ticket> GetTicketsByUserId(string userId)
        {
            ShoppingCart shoppingCart = GetShoppingCartByUserId(userId);
            return TheUnitOfWork.ShoppingCartTicket.getTicketsByShoppingCartId(shoppingCart.ID);
        }

        public Ticket AddTicketToShoppingCart(int eventId, string userId)
        {
            ShoppingCart shoppingCart = GetShoppingCartByUserId(userId);

            Ticket newTicket = new Ticket { clientId = userId, eventId = eventId };

            TheUnitOfWork.Ticket.Insert(newTicket);

            TheUnitOfWork.Commit();

            TheUnitOfWork.ShoppingCartTicket.Insert(new ShoppingCartTicket
            {
                shoppingCartId = shoppingCart.ID,
                ticketId = newTicket.ID
            });

            TheUnitOfWork.Commit();

            return newTicket;
        }

        public ShoppingCart Insert(string id)
        {
            ShoppingCart newSC = TheUnitOfWork.ShoppingCart.Insert(new ShoppingCart { ClientId = id });
            TheUnitOfWork.Commit();
            return newSC;
        }

        public void Commit()
        {
            TheUnitOfWork.Commit();
        } 
    }
}
