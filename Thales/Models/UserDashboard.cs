﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Thales.Models
{
	public class UserDashboard
	{
		public Building mBuilding { get; set; }
		public AnnouncementsList mAnnList { get; set;}
		public BillsList mBillsList { get; set; }
		public User mUser { get; set; }
		public Appartment mApprt { get; set; }
	}
}