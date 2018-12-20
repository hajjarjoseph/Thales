using Parse;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Thales.Controllers
{
    public class AddBillController : Controller
    {
        // GET: AddBill
        public ActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public async Task<ActionResult> Add()
		{
			String bType = Request.Form["TypeSelect"];
			String bTimeStr = Request.Form["dateInput"];
			float bAmount = float.Parse(Request.Form["AmountInput"], CultureInfo.InvariantCulture.NumberFormat); 
			DateTime bTime = Convert.ToDateTime(bTimeStr);
			HttpPostedFileBase currentFile = Request.Files[0];

			string fileName = currentFile.FileName;

			MemoryStream target = new MemoryStream();
			currentFile.InputStream.CopyTo(target);
			byte[] data = target.ToArray();

			ParseFile file = new ParseFile(fileName, data);
			await file.SaveAsync();

			ParseObject bill = new ParseObject("Bills");
			bill["Type"] = bType;
			bill["Price"] = bAmount;
			bill["Date"] = bTime;
			bill["Receipt"] = file;
			await bill.SaveAsync();

			ParseObject userBuilding = ParseUser.CurrentUser.Get<ParseObject>("Building");
			await userBuilding.FetchAsync();

			await bill.FetchAsync();

			userBuilding.AddToList("BillsList",bill.ObjectId);
			await userBuilding.SaveAsync();


			return RedirectToAction("Index", "AdminNavigation");

		}
	}
}