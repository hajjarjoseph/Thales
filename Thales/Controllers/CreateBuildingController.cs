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
    public class CreateBuildingController : Controller
    {
        // GET: CreateBuilding
        public ActionResult Index()
        {
			if (ParseUser.CurrentUser != null) 
			{
				return View();
			}
			else {
				return RedirectToAction("Index", "login");
			}

            
        }

		[HttpPost]
		public async Task<ActionResult> CreateBuilding(Building building)
		{

			String bName = building.buildingName;
			String bLoc = building.location;
			int bNumApparts = building.numApparts;
			int bNumShares = building.totalShares;
			float bTreasury = building.treasuryBalance;

			String optionResult = Request.Form["exampleRadioz"];
			String bCurrency;
			if (optionResult.Equals("option1"))
			{
				bCurrency = "$";
			}
			else {
				bCurrency = "LBP";
			}

			ParseObject buildingParse = new ParseObject("Building");
			ParseObject appartParse = new ParseObject("Appartment");
			buildingParse["Name"] = bName;
			buildingParse["location"] = bLoc;
			buildingParse["NumApparts"] = bNumApparts;
			buildingParse["totalShares"] = bNumShares;
			buildingParse["Manager"] = ParseUser.CurrentUser;
			buildingParse["Treasury"] = bTreasury;
			buildingParse["Currency"] = bCurrency;
			buildingParse["BillsList"] = new List<String>();


			List<ParseObject> apparts = new List<ParseObject>();

			for (int i = 1; i <= bNumApparts; i++)
			{
				appartParse = new ParseObject("Appartment");
				appartParse["Name"] = "Apart " + i;
				String appShareConfig = "appShare" + i;

				double appShare = double.Parse(Request.Form[appShareConfig], System.Globalization.CultureInfo.InvariantCulture);
				appartParse["Building"] = buildingParse;
				appartParse["AppShare"] = appShare;
				apparts.Add(appartParse);
			}

		
			try
			{
				await buildingParse.SaveAsync();

				await buildingParse.FetchAsync();

				//Storing building info 
				Building mBuilding = new Building();
				mBuilding.id = buildingParse.ObjectId;
				mBuilding.buildingName = buildingParse.Get<string>("Name");
				mBuilding.location = buildingParse.Get<string>("location");
				mBuilding.treasuryBalance = buildingParse.Get<float>("Treasury");
				mBuilding.totalShares = buildingParse.Get<int>("totalShares");
				mBuilding.currency = buildingParse.Get<string>("Currency");
				List<Object> tempList = buildingParse.Get<List<Object>>("BillsList");
				String billId;
				List<String> billsListStr = new List<string>();
				foreach (Object obj in tempList)
				{
					billId = obj.ToString();
					billsListStr.Add(billId);
				}
				mBuilding.billsList = billsListStr;
				UserDashboard userDash = new UserDashboard();
				userDash.mBuilding = mBuilding;


				TempData["myBuilding"] = userDash.mBuilding;


				ParseUser.CurrentUser["Building"] = buildingParse;
				await ParseUser.CurrentUser.SaveAsync();
				await ParseObject.SaveAllAsync(apparts);
				return RedirectToAction("Index", "AdminNavigation");
			}
			catch (ParseException e) {
				return new EmptyResult();
			}
			


			

		}
	}
}