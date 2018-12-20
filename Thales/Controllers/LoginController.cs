using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Parse;
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
        public async Task<ActionResult> SignIn(User pUser)
        {

            try
            {
                await ParseUser.LogInAsync(pUser.email, pUser.password);
				// Login was successful.

			

				Debug.WriteLine("************ login succesfull *********");
				return RedirectToAction("Index", "UsersDash");
			}
            catch (Exception e)
            {
                // The login failed. Check the error to see why.
                Debug.WriteLine("************ error login *********" + e);
				return RedirectToAction("Index", "login");


			}
            
        }


    }
}