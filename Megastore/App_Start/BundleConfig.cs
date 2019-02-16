using System.Web;
using System.Web.Optimization;

namespace Megastore
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles) {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/css/admin").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bower_components/font-awesome/css/font-awesome.css",
                      "~/Content/bower_components/Ionicons/css/ionicons.css",
                      "~/Content/dist/css/AdminLTE.css",
                      "~/Content/dist/css/skins/skin-blue.css"));

            bundles.Add(new ScriptBundle("~/bundles/admin").Include(
                      "~/Content/dist/js/adminlte.js"));
        }
    }
}
