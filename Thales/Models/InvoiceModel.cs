using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Thales.Models
{
	
	public class InvoiceModel
	{
		public Building mBuilding { get; set; }
		public BillsList mBillsList { get; set; }
		public Appartment myApprt { get; set; }
		public User myUser { get; set; }
	}
}