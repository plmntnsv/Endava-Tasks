using System;
using System.Web;
using System.Web.Mvc;
using TestApp.Common.Exceptions;
using TestApp.Common.Models;
using TestApp.Services.Contracts;

namespace TestApp.WebClient.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginUserViewModel user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // hash user password
                    var existingUser = userService.LoginUser(user);
                }
                catch(InvalidCredentialsException e)
                {
                    ModelState.AddModelError("", e.Message);
                    return View(user);
                }
                catch (Exception)
                {
                    return View("Error");
                }

                string authId = Guid.NewGuid().ToString();

                Session["AuthId"] = authId;
                Session["SessionUser"] = user.Email;
                Session.Timeout = 5;

                var cookie = new HttpCookie("AuthId")
                {
                    Value = authId,
                    //Expires = DateTime.Now.AddMinutes(10)
                };

                Response.Cookies.Add(cookie);

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return View(user);
            }
        }

        public ActionResult Logout()
        {
            Session["AuthId"] = null;
            Session["SessionUser"] = null;

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterUserViewModel user)
        {
            if (ModelState.IsValid)
            {
                try
                {

                }
                catch (UserExistsException e)
                {
                    ModelState.AddModelError("", e.Message);
                    return View();
                }
            }

            return RedirectToAction("Index", "Dashboard");
        }
    }
}