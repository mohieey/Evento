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
    public class ShoppingCartController : Controller
    {
        ShoppingCartAppService shoppingCartAppService = new ShoppingCartAppService(); 
        OrderAppService orderAppService = new OrderAppService();
        AccountAppService AccountAppService = new AccountAppService();
        
        [Authorize(Roles = "User")]

        public ActionResult Index()
        {
            return View(shoppingCartAppService.GetShoppingCartTicketsByUserId(User.Identity.GetUserId()));
        }

        public ActionResult Details()
        {
            return View();
        }

        [HttpPost]
        public void AddTicket(int eventId)
        {
            Ticket newTicket = shoppingCartAppService.AddTicketToShoppingCart(eventId, User.Identity.GetUserId());
            //return RedirectToAction("Index", "Event");
        }
    }
}
