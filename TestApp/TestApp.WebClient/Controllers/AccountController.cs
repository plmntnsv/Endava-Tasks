using System;
using System.Web;
using System.Web.Mvc;
using TestApp.Common.Exceptions;
using TestApp.Common.Hashing;
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
                    userService.LoginUser(user);
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

                CreateSession(user.Email);

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
                    var hashedPassword = HashingProvider.GenerateHash(user.Password);
                    user.Password = hashedPassword;

                    this.userService.RegisterUser(user);

                    CreateSession(user.Email);
                }
                catch (UserExistsException e)
                {
                    ModelState.AddModelError("", e.Message);
                    return View(user);
                }
                catch (Exception)
                {
                    return View("Error");
                }

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return View(user);
            }
        }

        [NonAction]
        private void CreateSession(string email)
        {
            string authId = Guid.NewGuid().ToString();

            Session["AuthId"] = authId;
            Session["SessionUser"] = email;
            Session.Timeout = 5;

            var cookie = new HttpCookie("AuthId")
            {
                Value = authId,
                //Expires = DateTime.Now.AddMinutes(10)
            };

            Response.Cookies.Add(cookie);
        }
    }
}