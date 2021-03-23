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
        

        // GET: ShoppingCart
        public ActionResult Index(string userId)
        {
            //return View("Index", shoppingCartAppService.GetShoppingCartByUserId(User.Identity.GetUserId()));
            return View();
        }

        // GET: ShoppingCart/Details/5
        public ActionResult Details()//int id)
        {
            return View();
        }



        public ActionResult AddTicketToCart(Ticket ticket)
        {
            ticket.OrderID = 5;
            shoppingCartAppService.AddTicketToShoppingCart(ticket);
            return RedirectToAction("Index", "Event");
        }



        public ActionResult CheckOut(ShoppingCart shoppingCart)
        {
            ClientUser client = AccountAppService.GetClientByUserId(User.Identity.GetUserId());

            Order order = new Order();
            order.tickets = shoppingCart.Tickets;
            shoppingCart.Tickets.Clear();

            client.orders.Add(order);

            shoppingCartAppService.Commit();

            return RedirectToAction("Index", "Event");
           
        }
    }
}
