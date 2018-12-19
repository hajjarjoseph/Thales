using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Thales.Models;

namespace Thales.Controllers
{
    public class UsersDashController : Controller
    {
		public UserDashboard userDash;
		// GET: UsersDash
		public async Task<ActionResult> Index()
        {
			
			userDash = new UserDashboard();
			

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
			foreach (Object obj in tempList)
			{
				billId = obj.ToString();
				billsListStr.Add(billId);
			}
			mBuilding.billsList = billsListStr;
			userDash.mBuilding = mBuilding;


			TempData["myBuilding"] = userDash.mBuilding;
	
			


			User currUser = new Models.User();
			currUser.firstName = ParseUser.CurrentUser.Get<string>("firstName");
			currUser.lastName = ParseUser.CurrentUser.Get<string>("lastName");

			userDash.mUser = currUser;


			return View(userDash);
        }


	

	}
}