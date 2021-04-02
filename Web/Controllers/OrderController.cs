using BL.AppServices;
using BL.ViewModels;
using DAL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class OrderController : Controller
    {
        OrderAppService orderAppService = new OrderAppService();
        ShoppingCartAppService ShoppingCartAppService = new ShoppingCartAppService();

        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int totalPrice)
        {
            Order newOrder = orderAppService.InsertOrder(User.Identity.GetUserId(), totalPrice);

            var ticketList = ShoppingCartAppService.GetTicketsByUserId(User.Identity.GetUserId());

            orderAppService.TransferTicketsToOrder(newOrder, ticketList);

            return View("receipt",newOrder);
        }

        public ActionResult Details()
        {
            return View();
        }
    }
}