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
    public class AddAnnouncementController : Controller
    {
		private Building mBuilding;
		private AnnouncementsList AnnList;
		
        // GET: AddAnnouncement
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {

			mBuilding = TempData["myBuilding"] as Building;
			TempData.Keep("myBuilding");

			var query = ParseObject.GetQuery("Building").WhereEqualTo("objectId",mBuilding.id);


			IEnumerable<ParseObject> results = await query.FindAsync();

			foreach (ParseObject userData in results)
			{
			
				var annQuery = ParseObject.GetQuery("Announcement").WhereEqualTo("Building", userData);
				IEnumerable<ParseObject> annResults = await annQuery.FindAsync();
				AnnList = new AnnouncementsList();
				AnnList.annList = new List<Announcement>();
				Announcement tempAnn;
				foreach (ParseObject obj in annResults)
				{
					tempAnn = new Announcement();
					tempAnn.message = obj.Get<string>("Message");
					AnnList.annList.Add(tempAnn);
				}

				AnnList.size = AnnList.annList.Count;

				}

				return View(AnnList);
        }


		[HttpPost]
		public async Task<ActionResult> Add()
		{
			String aMessage = Request.Form["aText"];

			mBuilding = TempData["myBuilding"] as Building;
			TempData.Keep("myBuilding");
			var query = ParseObject.GetQuery("Building").WhereEqualTo("objectId", mBuilding.id);


			IEnumerable<ParseObject> results = await query.FindAsync();

			foreach (ParseObject userData in results)
			{
				ParseObject announcement = new ParseObject("Announcement");
				announcement["Message"] = aMessage;
				announcement["Building"] = userData;

				await announcement.SaveAsync();

			}
				

			return RedirectToAction("Index", "AdminNavigation");

		}


	}
}