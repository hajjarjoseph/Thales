using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Parse;
using System.Configuration;

namespace Thales
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ParseClient.Initialize(new ParseClient.Configuration
            {
                ApplicationId = ConfigurationManager.AppSettings["APP_ID"],
                WindowsKey = ConfigurationManager.AppSettings["DotNetKey"],

                // the serverURL of your hosted Parse Server
                Server = "http://sabis-1.herokuapp.com/parse/"
            });

        }
    }
}
