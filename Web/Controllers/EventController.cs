using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Host")]
        public ActionResult CreateEvent() => View();

        //[HttpPost]
        //public ActionResult CreateEvent()
        //{

        //}
    }
}