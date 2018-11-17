using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thales.Models;

namespace Thales.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(User pUser)
        {
            System.Diagnostics.Debug.WriteLine(pUser.Password);
            return RedirectToAction("Index", "Login");
        }


    }
}