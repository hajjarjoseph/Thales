using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Parse;

namespace Thales.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public async System.Threading.Tasks.Task<string> getMsgAsync()
        {
            var nameS = "";
            ParseQuery<ParseObject> query = ParseObject.GetQuery("Test_Env");
            ParseObject name = await query.GetAsync("VxfxgFC3ms").ConfigureAwait(false);

            nameS =  name.Get<string>("Name");

            return nameS;
            

        }
    }
}