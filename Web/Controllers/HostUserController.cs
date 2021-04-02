using BL.AppServices;
using BL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    [Authorize]
    public class HostUserController : Controller
    {
        HostUserAppService hostAppService = new HostUserAppService();
        public ActionResult Index()
        {
            return View(hostAppService.GetAllHostUser().FirstOrDefault());
        }

        public ActionResult Details(string id)
        {
            return View(hostAppService.GetHostById(id));
        }

        public ActionResult Edit(string id)
        {
            HostUserViewModel hostUserVM = hostAppService.GetHostById(id);
            return View(hostUserVM);
        }

        [HttpPost]
        public ActionResult Edit(HostUserViewModel updateHostUser)
        {
            if (ModelState.IsValid)
            {
                hostAppService.UpdateHostUser(updateHostUser);
                return RedirectToAction("Details", new { id = updateHostUser.ID });
            }
            return View(updateHostUser);
        }

    }
}