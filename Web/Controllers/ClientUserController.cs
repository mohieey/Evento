﻿using System;
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
using DAL.User;
using Microsoft.AspNet.Identity;

namespace Web.Controllers
{
    [Authorize]
    public class ClientUserController : Controller
    {
        ClientUserAppService clientAppService = new ClientUserAppService();
        public ActionResult Index()
        {            
            return View(clientAppService.GetAllClientUser());
        }

        public ActionResult Details(string id)
        {
            return View(clientAppService.GetClientById(id));
        }

        public ActionResult Edit(string id)
        {
            ClientUserViewModel clientUserVM = clientAppService.GetClientById(id);
            return View(clientUserVM);
        }

        [HttpPost]
        public ActionResult Edit(ClientUserViewModel updateClientUser)
        {
            if (ModelState.IsValid)
            {
                clientAppService.UpdateClientUser(updateClientUser);
                return RedirectToAction("Details", new { id = updateClientUser.ID});
            }
            return View(updateClientUser);
        }
    }
}
