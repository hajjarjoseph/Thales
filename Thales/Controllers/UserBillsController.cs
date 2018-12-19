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
    public class UserBillsController : Controller
    {

		private Building mBuilding;
		private BillsList mBillsList;

        // GET: UserBills
        public async Task<ActionResult> Index()
        {
			mBuilding = TempData["myBuilding"] as Building ;
			TempData.Keep("myBuilding");
			await GetBills();

			return View(mBillsList);
        }

		
		public async Task GetBills()
		{
			var query = ParseObject.GetQuery("Bills").WhereContainedIn("objectId", mBuilding.billsList);

			IEnumerable<ParseObject> results = await query.FindAsync();

			mBillsList = new BillsList();
			mBillsList.billsArray = new List<Bills>();
			Bills zBill = new Bills();
			foreach (ParseObject userData in results) {

				zBill = new Bills();
				zBill.type = userData.Get<string>("Type");
				zBill.price = userData.Get<float>("Price");
				zBill.date = userData.Get<DateTime>("Date");
				zBill.id = userData.ObjectId;

				mBillsList.billsArray.Add(zBill);
			}

			mBillsList.size = mBillsList.billsArray.Count;


		}
		

	}

	
}