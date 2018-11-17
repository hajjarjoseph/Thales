using System.Web;
using System.Web.Optimization;

namespace Thales
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                    "~/Scripts/core/jquery.min.js",
                     "~/Scripts/core/popper.min.js",
                    "~/Scripts/core/bootstrap.min.js",
                    "~/Scripts/paper-dashboard.min.js",
                    "~/Scripts/plugins/jquery.validate.min.js",
                    "~/Scripts/plugins/jquery.bootstrap-wizard.js",
                    "~/Scripts/plugins/jquery.dataTables.min.js",
                    "~/Scripts/plugins/jquery-jvectormap.js",
                    "~/Scripts/plugins/perfect-scrollbar.jquery.min.js",
                     "~/Scripts/plugins/moment.min.js",


                    "~/Scripts/plugins/bootstrap-notify.js",
                    "~/Scripts/plugins/chartjs.min.js",
                    "~/Scripts/plugins/nouislider.min.js",
                    "~/Scripts/plugins/jasny-bootstrap.min.js",
                    "~/Scripts/plugins/bootstrap-tagsinput.js",
                   
                    "~/Scripts/plugins/bootstrap-datetimepicker.js",
                    "~/Scripts/plugins/bootstrap-selectpicker.js",
              
                   
                    "~/Scripts/plugins/sweetalert2.min.js",
                    "~/Scripts/plugins/bootstrap-switch.js",
                   
                 
                   
                  
                    "~/Scripts/respond.js"
                    
                    ));

            bundles.Add(new ScriptBundle("~/bundles/loginB").Include(
                    "~/Ress/Login_Ress/vendor/jquery/jquery-3.2.1.min.js",
                     "~/Ress/Login_Ress/vendor/animsition/js/animsition.min.js",
                    "~/Ress/Login_Ress/vendor/bootstrap/js/popper.js",
                    "~/Ress/Login_Ress/vendor/bootstrap/js/bootstrap.min.js",
                    "~/Ress/Login_Ress/vendor/select2/select2.min.js",
                    "~/Ress/Login_Ress/vendor/daterangepicker/moment.min.js",
                    "~/Ress/Login_Ress/vendor/daterangepicker/daterangepicker.js",
                    "~/Ress/Login_Ress/vendor/countdowntime/countdowntime.js",
                    "~/Ress/Login_Ress/js/main-login.js"
                    ));


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

          

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/paper-dashbaord.css"
                     ));
        }
    }
}
