using Parse;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Thales.Models;

namespace Thales.Controllers
{
    public class SignUpController : Controller
    {
        // GET: SignUp
        public ActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public async Task<ActionResult> Register(User pUser)
		{


		
				var user = new ParseUser()
				{
					Username = pUser.email,
					Password = pUser.password,
					Email = pUser.email
				};

				// other fields can be set just like with ParseObject
				user["firstName"] = pUser.firstName;
			    user["lastName"] = pUser.lastName;
			    user["phoneNumber"] = pUser.phoneNumber;

			try
			{
				await user.SignUpAsync();
				// Login was successful.
				Debug.WriteLine("************ Sign Up succesfull *********");
			}
			catch (Exception e)
			{
				// The login failed. Check the error to see why.
				Debug.WriteLine("************ error SignUp *********" + e);


			}
			return RedirectToAction("Index", "login");

		}
	}
}