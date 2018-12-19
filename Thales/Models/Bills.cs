using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Thales.Models
{
	public class Bills
	{
		public String id { get; set; }
		public String type { get; set; }
		public float price { get; set; }
		public DateTime date { get; set; }
	}
}