using System.Web;
using System.Web.Optimization;

namespace ClientManager
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery-ui-{version}.js",
                "~/Scripts/datatables/jquery.datatables.js",
                "~/Scripts/knockout-{version}",
                "~/Scripts/datatables/datatables.bootstrap.js",
                "~/Scripts/toastr.js",
                "~/Scripts/ToastrCustomNotification.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                  "~/Content/Gentelella_Theme/gentelella.css",
                "~/Content/font-awesome.css",
                "~/Content/themes/base/jquery-ui.css",
                "~/Content/datatables/css/datatables.bootstrap.css"//,
                //"~/Content/toastr.css"
                ));
        }
    }
}
