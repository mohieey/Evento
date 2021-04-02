using BL.AppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        AccountAppService accountAppService = new AccountAppService();
        EventAppService eventAppService = new EventAppService();
        OrderAppService orderAppService = new OrderAppService();

        public ActionResult Clients()
        {
            return View(accountAppService.GetAllClients());
        }

        public ActionResult Hosts()
        {
            return View(accountAppService.GetAllHosts());
        }

        public ActionResult Events()
        {
            return View(eventAppService.GetAllEvents());
        }

        public ActionResult Orders()
        {
            return View(orderAppService.GetOrders());
        }
    }
}