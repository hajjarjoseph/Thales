using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Thales.Models
{
	public class Building
	{
		public String id { get; set; }
		public string buildingName { get; set; }
		public string location { get; set; }
		public int numApparts { get; set; }
		public int totalShares { get; set; }
		public float treasuryBalance { get; set; }
		public string currency { get; set; }
		public List<String> billsList { get; set; }



	}
}