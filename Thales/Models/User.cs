using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Thales.Models
{
    public class User
    {
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
		public string confirmPassword { get; set; }
		public string phoneNumber { get; set; }
		public string firstName { get; set; }
		public string lastName { get; set; }



	}
}