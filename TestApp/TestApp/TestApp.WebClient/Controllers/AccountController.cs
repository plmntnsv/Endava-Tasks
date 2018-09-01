using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApp.Services.Contracts;

namespace TestApp.WebClient.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService service;
        private static readonly Random rnd = new Random();

        public AccountController(IUserService service)
        {
            this.service = service;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            this.service.GetUserById(1);
            return View();
        }
    }
}