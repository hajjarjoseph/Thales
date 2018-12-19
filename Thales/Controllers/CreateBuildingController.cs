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

			ParseObject buildingParse = new ParseObject("Building");
			ParseObject appartParse = new ParseObject("Appartment");
			buildingParse["Name"] = bName;
			buildingParse["location"] = bLoc;
			buildingParse["NumApparts"] = bNumApparts;
			buildingParse["totalShares"] = bNumShares;
			buildingParse["Manager"] = ParseUser.CurrentUser;

			List<ParseObject> apparts = new List<ParseObject>();

			for (int i = 1; i <= bNumApparts; i++)
			{
				appartParse = new ParseObject("Appartment");
				appartParse["Name"] = "Apart" + i;
				String appShareConfig = "appShare" + i;

				double appShare = double.Parse(Request.Form[appShareConfig], System.Globalization.CultureInfo.InvariantCulture);
				appartParse["Building"] = buildingParse;
				appartParse["AppShare"] = appShare;
				apparts.Add(appartParse);
			}

		
			try
			{
				await buildingParse.SaveAsync();
				await ParseObject.SaveAllAsync(apparts);
				return RedirectToAction("Index", "login");
			}
			catch (ParseException e) {
				return new EmptyResult();
			}
			


			

		}
	}
}