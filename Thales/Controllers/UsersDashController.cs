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
		public ParseObject userBuilding;
		// GET: UsersDash
		public async Task<ActionResult> Index()
        {
			
			userDash = new UserDashboard();


			await GetBuilding();
			await GetBills();
			await GetMyAppart();
			
			User currUser = new Models.User();
			currUser.firstName = ParseUser.CurrentUser.Get<string>("firstName");
			currUser.lastName = ParseUser.CurrentUser.Get<string>("lastName");
			currUser.email = ParseUser.CurrentUser.Username;
			currUser.phoneNumber = ParseUser.CurrentUser.Get<string>("phoneNumber");

			userDash.mUser = currUser;

			TempData["myUser"] = userDash.mUser;


			return View(userDash);
        }

		public async Task GetBuilding() {



			userBuilding = ParseUser.CurrentUser.Get<ParseObject>("Building");
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

			await GetAnnouncements();
			TempData["myBuilding"] = userDash.mBuilding;
		}

		public async Task GetAnnouncements()
		{

			var annQuery = ParseObject.GetQuery("Announcement").WhereEqualTo("Building", userBuilding);
			IEnumerable<ParseObject> annResults = await annQuery.FindAsync();

			userDash.mAnnList = new AnnouncementsList();
			userDash.mAnnList.annList = new List<Announcement>();
			Announcement tempAnn;
			foreach (ParseObject pObj in annResults) {
				tempAnn = new Announcement();
				tempAnn.message = pObj.Get<string>("Message");
				userDash.mAnnList.annList.Add(tempAnn);
			}

			userDash.mAnnList.size = userDash.mAnnList.annList.Count;

		
		}

		public async Task GetBills()
		{

			var query = ParseObject.GetQuery("Bills").WhereContainedIn("objectId", userDash.mBuilding.billsList);

			IEnumerable<ParseObject> results = await query.FindAsync();

			userDash.mBillsList = new BillsList();
			userDash.mBillsList.billsArray = new List<Bills>();
			Bills zBill = new Bills();
			float max = 0;
			foreach (ParseObject userData in results)
			{

				zBill = new Bills();
				zBill.type = userData.Get<string>("Type");
				zBill.price = userData.Get<float>("Price");
				if (zBill.price > max) {
					max = zBill.price;
				}
				zBill.date = userData.Get<DateTime>("Date");
				zBill.id = userData.ObjectId;
				zBill.receipt = userData.Get<ParseFile>("Receipt");

				zBill.imgUrl = zBill.receipt.Url.AbsoluteUri;

				userDash.mBillsList.billsArray.Add(zBill);
			}

			TempData["myBills"] = userDash.mBillsList;
			userDash.mBillsList.size = userDash.mBillsList.billsArray.Count;
			userDash.mBillsList.mostExpensiveBill = max;
			


		}

		public async Task GetMyAppart()
		{

			var appQuery = ParseObject.GetQuery("Appartment").WhereEqualTo("Building", userBuilding);
			IEnumerable<ParseObject> appResults = await appQuery.FindAsync();

			
			userDash.mApprt = new Appartment();
			foreach (ParseObject pObj in appResults)
			{


				List<Object> tempList = pObj.Get<List<Object>>("owners");
				String owner;
				List<String> ownersList = new List<string>();
				foreach (Object appObj in tempList)
				{
					owner = appObj.ToString();
					ownersList.Add(owner);
				}


				if (ownersList.Contains(ParseUser.CurrentUser.ObjectId)){
					userDash.mApprt.settlement = pObj.Get<float>("Settlement");
					userDash.mApprt.name = pObj.Get<string>("Name");
					TempData["myApprt"] = userDash.mApprt;
				}
			}

			


		}




	}
}