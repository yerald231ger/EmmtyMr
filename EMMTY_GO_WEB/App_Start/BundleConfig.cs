using System.Web;
using System.Web.Optimization;

namespace EMMTY_GO_WEB
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js","~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate.min.js", "~/Scripts/jquery.validate.unobtrusive.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/raphaeljs").Include(
                "~/Scripts/raphael-min.js"));

            bundles.Add(new ScriptBundle("~/bundles/chartjs").Include(
                "~/Scripts/Chart.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.


            bundles.Add(new ScriptBundle("~/bundles/personalsScripts").Include(
                "~/Scripts/PersonalsScripts.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css",
                "~/Content/PersonalCSS.css"));

            bundles.Add(new StyleBundle("~/Content/jquery-ui").Include(
                "~/Content/themes/base/theme.css", "~/Content/themes/base/datepicker.css"));

        }
    }
}
