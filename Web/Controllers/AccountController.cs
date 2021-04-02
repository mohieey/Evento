using BL.AppServices;
using BL.ViewModels;
using DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        AccountAppService accountAppService = new AccountAppService();
        ShoppingCartAppService ShoppingCartAppService = new ShoppingCartAppService();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register(bool isHost = false)
        {
            ViewBag.isHost = isHost;
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel newUser, bool isHost = false)
            {
            if (!ModelState.IsValid)
            {
                return View(newUser);
            }
            IdentityResult result = accountAppService.Register(newUser, isHost, User.IsInRole("Admin"));
            if (result.Succeeded)
            {
                ApplicationIdentityUser registeredUser = accountAppService.Find(newUser.UserName, newUser.PasswordHash);

                if (User.IsInRole("Admin"))
                    accountAppService.AssignToRole(registeredUser.Id, "Admin");
                else
                {
                    if (isHost)
                        accountAppService.AssignToRole(registeredUser.Id, "Host");
                    else
                    {
                        accountAppService.AssignToRole(registeredUser.Id, "User");
                        ShoppingCartAppService.Insert(registeredUser.Id);
                    }
                }
                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError("", result.Errors.FirstOrDefault());
                return View(newUser);
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AddAdmin() => 
            RedirectToAction("Register","Account");

        public ActionResult Login() => View();

        [HttpPost]
        public ActionResult Login(LoginViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            else
            {
                ApplicationIdentityUser identityUser = accountAppService.Find(user.UserName, user.PasswordHash);

                if (identityUser != null)
                {
                    IAuthenticationManager owinMAnager = HttpContext.GetOwinContext().Authentication;

                    var signinmanager = new SignInManager<ApplicationIdentityUser, string>(
                            new ApplicationUserManager(), owinMAnager
                            );
                    signinmanager.SignIn(identityUser, true, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Not Valid Username & Password");
                    return View(user);
                }
            }
        }

        [Authorize]
        public ActionResult Logout()
        {
            IAuthenticationManager owinMAnager = HttpContext.GetOwinContext().Authentication;
            owinMAnager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login");
        }
    }
}