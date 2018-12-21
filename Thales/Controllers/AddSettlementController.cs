using Parse;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Thales.Models;

namespace Thales.Controllers
{
	public class AddSettlementController : Controller
	{
		// GET: AddSettlement
		public Building mBuilding;
		public AppartmentsList mAppList;
		public async System.Threading.Tasks.Task<ActionResult> Index()
		{
			mBuilding = TempData["myBuilding"] as Building;
			TempData.Keep("myBuilding");

			var query = ParseObject.GetQuery("Building").WhereEqualTo("objectId", mBuilding.id);


			IEnumerable<ParseObject> results = await query.FindAsync();

			foreach (ParseObject userData in results)
			{
				var appQuery = ParseObject.GetQuery("Appartment").WhereEqualTo("Building", userData);
				IEnumerable<ParseObject> appResults = await appQuery.FindAsync();
				mAppList = new AppartmentsList();
				mAppList.appList = new List<Appartment>();
				Appartment tempApp;
				foreach (ParseObject pObj in appResults)
				{

					tempApp = new Appartment();
					tempApp.name = pObj.Get<string>("Name");
					tempApp.objId = pObj.ObjectId;
					tempApp.settlement = pObj.Get<float>("Settlement");

					mAppList.appList.Add(tempApp);

				}

				mAppList.size = mAppList.appList.Count;
				
			}
			return View(mAppList);

		}


		[HttpPost]
		public async Task<ActionResult> Add()
		{
			int pos = Int32.Parse(Request.Form["iden"]);

			float addAmountSt = float.Parse(Request.Form["addAmount"], CultureInfo.InvariantCulture.NumberFormat);
			float negAmountSt = float.Parse(Request.Form["negAmount"], CultureInfo.InvariantCulture.NumberFormat);

			mBuilding = TempData["myBuilding"] as Building;
			TempData.Keep("myBuilding");

			var query = ParseObject.GetQuery("Building").WhereEqualTo("objectId", mBuilding.id);


			IEnumerable<ParseObject> results = await query.FindAsync();

			foreach (ParseObject userData in results)
			{
				var appQuery = ParseObject.GetQuery("Appartment").WhereEqualTo("Building", userData);
				IEnumerable<ParseObject> appResults = await appQuery.FindAsync();
				mAppList = new AppartmentsList();
				mAppList.appList = new List<Appartment>();
				Appartment tempApp;
				foreach (ParseObject pObj in appResults)
				{

					tempApp = new Appartment();
					tempApp.name = pObj.Get<string>("Name");
					tempApp.objId = pObj.ObjectId;
					tempApp.settlement = pObj.Get<float>("Settlement");

					mAppList.appList.Add(tempApp);

				}

				mAppList.size = mAppList.appList.Count;

				var queryApp = ParseObject.GetQuery("Appartment").WhereEqualTo("objectId", mAppList.appList[pos].objId);


				IEnumerable<ParseObject> resultsApp = await queryApp.FindAsync();

				foreach (ParseObject appObj in resultsApp)
				{
					if (negAmountSt == 0)
					{
						appObj["Settlement"] = appObj.Get<float>("Settlement") + addAmountSt;
					}
					else
					{
						appObj["Settlement"] = appObj.Get<float>("Settlement") - negAmountSt;
					}

					await appObj.SaveAsync();


				}

			}



			


			return RedirectToAction("Index", "AdminNavigation");

		}

	}
}