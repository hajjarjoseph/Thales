using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thales.Models;

namespace Thales.Controllers
{
	
    public class InvoiceController : Controller
    {
		public InvoiceModel invModel;
		// GET: Invoice
		public ActionResult Index()
        {
			invModel = new InvoiceModel();
			invModel.mBuilding = TempData["myBuilding"] as Building;
			TempData.Keep("myBuilding");
			invModel.mBillsList = TempData["myBills"] as BillsList;
			TempData.Keep("myBills");
			invModel.myUser = TempData["myUser"] as User;
			TempData.Keep("myUser");
			invModel.myApprt = TempData["myApprt"] as Appartment;
			TempData.Keep("myApprt");

			string subfoldername = "Invoice";
			//Your fileName
			string filename = "data.txt";
			string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, subfoldername, filename);
			string replacement = "";
			for (int i = 0; i < invModel.mBillsList.size; i++) {
				if (invModel.mBillsList.billsArray[i].type == "Elevator")
				{
					replacement += invModel.mBillsList.billsArray[i].type + "@||@1@||@" + invModel.mBillsList.billsArray[i].price + "@||@50@||@2\n";
				}
				else {
					replacement += invModel.mBillsList.billsArray[i].type + "@||@1@||@" + invModel.mBillsList.billsArray[i].price + "@||@@||@2\n";
				}
				
			}

			String text = System.IO.File.ReadAllText(path);
			text = text.Replace("Frozen Brontosaurus Ribs@||@4@||@120@||@@||@2", replacement);
			System.IO.File.WriteAllText(path, text);

			return View(invModel);
        }
    }
}