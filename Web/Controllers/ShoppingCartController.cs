using BL.AppServices;
using DAL;
using DAL.User;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    //[Authorize(Roles = "User")]
    public class ShoppingCartController : Controller
    {
        ShoppingCartAppService shoppingCartAppService = new ShoppingCartAppService(); 
        OrderAppService orderAppService = new OrderAppService();
        AccountAppService AccountAppService = new AccountAppService();
        
        [Authorize(Roles = "User")]
        // GET: ShoppingCart
        public ActionResult Index()
        {
            //shoppingCartAppService.GetShoppingCartByUserId(User.Identity.GetUserId());
            //return View("Index", shoppingCartAppService.GetShoppingCartByUserId(User.Identity.GetUserId()));
            return View(shoppingCartAppService.GetShoppingCartTicketsByUserId(User.Identity.GetUserId()));
        }

        // GET: ShoppingCart/Details/5
        public ActionResult Details()//int id)
        {
            return View();
        }



        public ActionResult AddTicket(int eventId)
        {
            Ticket newTicket = shoppingCartAppService.AddTicketToShoppingCart(eventId, User.Identity.GetUserId()) ;

            //ticket.OrderID = 1;
            //ticket.price = 22;
            //shoppingCartAppService.AddTicketToShoppingCart(ticket);
            return RedirectToAction("Index", "Event");
        }



        //public ActionResult CheckOut(ShoppingCart shoppingCart)
        //{
        //    ClientUser client = AccountAppService.GetClientByUserId(User.Identity.GetUserId());

        //    Order order = new Order();
        //    order.tickets = shoppingCart.Tickets;
        //    shoppingCart.Tickets.Clear();

        //    client.orders.Add(order);

        //    shoppingCartAppService.Commit();

        //    return RedirectToAction("Index", "Event");

        //}

    }
}
