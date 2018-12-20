using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thales.Models;

namespace Thales.Controllers
{
    public class InvitationsController : Controller
    {
		// GET: Invitations
		private Building mBuilding;
		private AppartmentsList mAppList;
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
				foreach (ParseObject pObj in appResults) {

					tempApp = new Appartment();
					tempApp.name = pObj.Get<string>("Name");
					tempApp.objId = pObj.ObjectId;

					mAppList.appList.Add(tempApp);

				}

				mAppList.size = mAppList.appList.Count;
		


			}
				return View(mAppList);
        }
    }
}