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

				ParseObject userBuilding = ParseUser.CurrentUser.Get<ParseObject>("Building");
				await userBuilding.FetchAsync();


				//Storing building info 
				Building mBuilding = new Building();
				mBuilding.id = userBuilding.ObjectId;
				mBuilding.buildingName = userBuilding.Get<string>("Name");
				mBuilding.location = userBuilding.Get<string>("location");
				mBuilding.treasuryBalance = userBuilding.Get<float>("Treasury");
				mBuilding.totalShares = userBuilding.Get<int>("totalShares");
				mBuilding.currency = userBuilding.Get<string>("Currency");
				List<Object> tempList = userBuilding.Get<List<Object>>("BillsList");
				String billId;
				List<String> billsListStr = new List<string>();
				foreach (Object obj in tempList) {
					billId = obj.ToString();
					billsListStr.Add(billId);
				}
				mBuilding.billsList = billsListStr;

				TempData["myBuilding"] = mBuilding;
				

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