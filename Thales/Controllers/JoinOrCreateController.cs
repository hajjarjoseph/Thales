using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Thales.Controllers
{
    public class JoinOrCreateController : Controller
    {
        // GET: JoinOrCreate
        public ActionResult Index()
        {
			if (ParseUser.CurrentUser != null)
			{
				return View();
			}
			else
			{
				return RedirectToAction("Index", "login");
			}
		}

		[HttpPost]
		public async Task<ActionResult> JoinBuilding()
		{
			String bId = Request.Form["pin"];
			var query = ParseObject.GetQuery("Appartment").WhereEqualTo("objectId", bId);
			IEnumerable<ParseObject> result = await query.FindAsync();

			bool isEmpty = true;

			foreach (var userData in result) {

				isEmpty = false;
				userData.AddToList("owners",ParseUser.CurrentUser.ObjectId);
				await userData.SaveAsync();
				ParseUser.CurrentUser["Building"] = userData.Get<ParseObject>("Building");
				await ParseUser.CurrentUser.SaveAsync();

				return RedirectToAction("Index", "UsersDash");

			}

			return new EmptyResult();

		}
		}
}