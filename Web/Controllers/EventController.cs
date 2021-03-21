using AutoMapper;
using BL.AppServices;
using BL.ViewModels;
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
    public class EventController : Controller
    {
        EventAppService eventAppService = new EventAppService();
        
        // GET: Event
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Host")]
        public ActionResult CreateEvent() => View();

        [HttpPost]
        [Authorize(Roles = "Host")]
        public ActionResult CreateEvent(EventViewModel newEvent)
        {
            AccountAppService accountAppService = new AccountAppService();
            newEvent.HostId = User.Identity.GetUserId();

            if (ModelState.IsValid == false)
                return View(newEvent);

            eventAppService.SaveNewEvent(newEvent);
            return RedirectToAction("Index");
        }
    }
}