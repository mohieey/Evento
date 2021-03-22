using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BL.AppServices;
using BL.ViewModels;
using DAL;

namespace Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TicketController : Controller
    {
        TicketAppService ticketAppService = new TicketAppService();
        public ActionResult Index()
        {
            return View(ticketAppService.GetAllTickets());
        }

        public ActionResult Details(int id)
        {
            TicketViewModel ticketViewModel = ticketAppService.GetTicketById(id);
            if (ticketViewModel == null)
            {
                return HttpNotFound();
            }
            return View(ticketViewModel);
        }

        public ActionResult Create() => View();


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TicketViewModel newTicket)
        {
            if (!ModelState.IsValid)
                return View(newTicket);

            try
            {
                ticketAppService.CreateTicket(newTicket);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }

        }

        //public ActionResult Edit(int id) => View();

        //[HttpPost]
        //public ActionResult Edit(int id, TicketViewModel updateTicket)
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
            TicketViewModel ticketViewModel = ticketAppService.GetTicketById(id);
            if (ticketViewModel == null)
            {
                return HttpNotFound();
            }
            return View(ticketViewModel);
        }

        [HttpPost]
        public ActionResult Delete(int id, TicketViewModel ticketVM)
        {
            if (!ModelState.IsValid)
                return View(ticketVM);
            try
            {
                ticketAppService.DeleteTicket(id);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
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
