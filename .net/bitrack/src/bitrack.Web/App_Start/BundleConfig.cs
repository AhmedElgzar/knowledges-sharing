using System.Web;
using System.Web.Optimization;

namespace bitrack.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/libs").Include(
                        "~/Scripts/libs/jquery-2.1.4.js",
                        "~/Scripts/libs/underscore.js",
                        "~/Scripts/libs/bootstrap.js",
                        "~/Scripts/libs/jquery.dataTables.js",
                        "~/Scripts/libs/bootstrap-datepicker.js",
                        "~/Scripts/libs/Chart.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/main").Include(
                       "~/Scripts/app/bitrack-charts.js",
                       "~/Scripts/app/bitrack-grids.js",
                       "~/Scripts/app/bitrack-filters.js",
                       "~/Scripts/app/bitrack-main.js"
                       ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-datepicker3.css",
                      "~/Content/jquery.dataTables.css",
                      "~/Content/dataTables.bootstrap.css",
                      "~/Content/admin-theme.css"
                      ));
        }
    }
}
