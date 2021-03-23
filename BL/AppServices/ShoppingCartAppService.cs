using BL.Bases;
using DAL;
using System;
using System.Collections.Generic;
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

        public Ticket AddTicketToShoppingCart(Ticket ticket)
        {
            ShoppingCart shoppingCart=  GetShoppingCartByUserId(ticket.clientId);
            shoppingCart.Tickets.Add(ticket);
            shoppingCart.totalPrice += ticket.price;
            TheUnitOfWork.Commit();
            
            return ticket;
        }


       public void Commit()
        {
            TheUnitOfWork.Commit();
        } 
    }
}
