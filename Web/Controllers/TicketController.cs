using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BL.AppServices;
using BL.ViewModels;
using DAL;
using Microsoft.AspNet.Identity;

namespace Web.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class TicketController : Controller
    {
        TicketAppService ticketAppService = new TicketAppService();
        public ActionResult Index()
        {
            return View(ticketAppService.GetAllTickets());
        }

        public ActionResult Details(int id)
        {
            Ticket Ticket = ticketAppService.GetTicketById(id);
            if (Ticket == null)
            {
                return HttpNotFound();
            }
            return View(Ticket);
        }

        //public ActionResult Create() => View();




        public ActionResult Create(Event _event)
        {
            //if (!ModelState.IsValid)
            //    return View(newTicket);

            //try
            //{
            if (_event.tickets.Count() == _event.TotalAvailableTickets)
            {
                return Content("Out Of Stock");
            }
            Ticket ticket = ticketAppService.CreateTicket(_event);
            //ticket.clientId = User.Identity.GetUserId();
            return RedirectToAction("AddTicketToCart", "ShoppingCart", new RouteValueDictionary(ticket));


            //catch(Exception ex)
            //{
            //    ModelState.AddModelError("", ex.Message);
            //    return View();
            //}

        }

        //public ActionResult Edit(int id) => View();

        //[HttpPost]
        //public ActionResult Edit(int id, Ticket updateTicket)
        //{
        //    if (!ModelState.IsValid)
        //        return View(updateTicket);
        //    try
        //    {

        //        ticketAppService.UpdateTicket(updateTicket);
        //        return RedirectToAction("Index");
        //    }
        //    catch(Exception ex)
        //    {
        //        ModelState.AddModelError("", ex.Message);
        //        return View();
        //    }
        //}

        public ActionResult Delete(int id)
        {
            Ticket Ticket = ticketAppService.GetTicketById(id);
            if (Ticket == null)
            {
                return HttpNotFound();
            }
            return View(Ticket);
        }

        [HttpPost]
        public ActionResult Delete(int id, Ticket ticketVM)
        {
            if (!ModelState.IsValid)
                return View(ticketVM);
            try
            {
                ticketAppService.DeleteTicket(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        ticketAppService.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
