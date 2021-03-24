using AutoMapper;
using BL.AppServices;
using BL.ViewModels;
using DAL;
using DAL.User;
using Microsoft.AspNet.Identity;
using PagedList;
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
        public ActionResult Index(string eventName, int? page)
        {
            if (!(eventName is null))
            {
                return View("Index", eventAppService.GetAllEvents()
                                                    .Where(e => e.Name
                                                    .Contains(eventName))
                                                    .ToList().ToPagedList(page ?? 1, 9));
            }

            return View(eventAppService.GetAllEvents().ToPagedList(page ?? 1, 9));
        }




        public ActionResult IndexByHostName(string hostName, int? page)
        {
            if (!(hostName is null))
            {
                return View("Index", eventAppService.GetAllEvents().Where(e => e.Host.user.UserName.Contains(hostName)).ToList().ToPagedList(page ?? 1, 9));

            }

            return View(eventAppService.GetAllEvents().ToPagedList(page ?? 1, 9));
        }






        public ActionResult IndexByCategory(Enum_Category? Category, int? page)
        {
            if (Category is null)
            {
                return View("Index", eventAppService.GetAllEvents().ToList().ToPagedList(page ?? 1, 9));

            }

            return View("Index", eventAppService.GetAllEvents().Where(e => e.category == Category).ToPagedList(page ?? 1, 9));
        }



        public ActionResult IndexByAge(Enum_Age? Age, int? page)
        {
            if (Age is null)
            {
                return View("Index", eventAppService.GetAllEvents().ToList().ToPagedList(page ?? 1, 9));

            }

            return View("Index", eventAppService.GetAllEvents().Where(e => e.age == Age).ToPagedList(page ?? 1, 9));
        }


        [Authorize(Roles = "Host")]
        public ActionResult CreateEvent() => View();

        [HttpPost]
        [Authorize(Roles = "Host")]
        public ActionResult CreateEvent(EventViewModel newEvent, HttpPostedFileBase file)
        {
            ViewBag.ImageError = null;
            if (!ModelState.IsValid || file == null)
            {
                if (file == null)
                    ViewBag.ImageError = "Please add an image for the event.";
                return View(newEvent);
            }

            var image = System.IO.Path.GetFileName(file.FileName);
            file.SaveAs(Server.MapPath("~/Content/" + image));
            newEvent.image = image;

            AccountAppService accountAppService = new AccountAppService();
            newEvent.HostId = User.Identity.GetUserId();

            eventAppService.SaveNewEvent(newEvent);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Host")]
        public ActionResult EditEvent(int id)
        {
            return View(eventAppService.GetEventById(id));
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Host")]
        public ActionResult EditEvent(EventViewModel editEvent, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string image;
                if (file != null)
                {
                    image = System.IO.Path.GetFileName(file.FileName);
                    file.SaveAs(Server.MapPath("~/Content/" + image));
                }
                else
                {
                    image = eventAppService.GetEventById(editEvent.ID).image;
                }
                editEvent.image = image;
                //editEvent.HostId = User.Identity.GetUserId();
                editEvent = eventAppService.EditEvent(editEvent);

                return RedirectToAction("Index");
            }
            else
            {
                return View(editEvent);
            }
        }


        //[Authorize(Roles = "Host")]
        //public ActionResult SaveChanges(EventViewModel editEvent)
        //{
            
        //    eventAppService.SaveEventChanges(editEvent);
   
        //    return RedirectToAction("Index");
        //}


        [Authorize]
        public ActionResult Details(int id)
        {

       

            return View(eventAppService.GetEventById(id));
        }
    }
}