﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Thales.Models
{
	public class BillsList
	{
		public List<Bills> billsArray { get; set; }
		public String mostFrequentType { get; set; }
		public float mostExpensiveBill { get; set; }
		public int size { get; set; }
	}
}