using System.Web;
using System.Web.Optimization;

namespace Apartamentos
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/head").Include(
                     "~/Scripts/lib/chart-master/Chart.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       "~/Scripts/lib/jquery/jquery*",
                       "~/Scripts/lib/bootstrap/js/bootstrap.min.js",
                       "~/Scripts/lib/jquery.dcjqaccordion.2.7.js",
                       "~/Scripts/lib/jquery.scrollTo.min.js",
                       "~/Scripts/lib/jquery.nicescroll.js",
                       "~/Scripts/lib/jquery.sparkline.js",
                       "~/Scripts/lib/advanced-datatable/js/jquery.dataTables.js",
                       "~/Scripts/lib/advanced-datatable/js/DT_bootstrap.js",
                       "~/Scripts/lib/bootstrap-fileupload/bootstrap-fileupload.js",
                       "~/Scripts/lib/fancybox/jquery.fancybox.js",
                       "~/Scripts/lib/bootstrap-datepicker/js/bootstrap-datepicker.js",
                       "~/Scripts/lib/bootstrap-daterangepicker/date.js",
                       "~/Scripts/lib/bootstrap-daterangepicker/daterangepicker.js",
                       "~/Scripts/lib/bootstrap-datetimepicker/js/bootstrap-datetimepicker.js",
                       "~/Scripts/lib/bootstrap-daterangepicker/moment.min.js",
                       "~/Scripts/lib/bootstrap-timepicker/js/bootstrap-timepicker.js",
                       "~/Scripts/lib/advanced-form-components.js",
                       "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/lib/common-scripts.js",
                        "~/Scripts/lib/gritter/js/jquery.gritter.js",
                        "~/Scripts/lib/gritter-conf.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                       "~/Scripts/lib/sparkline-chart.js",
                       "~/Scripts/lib/zabuto_calendar.js"));



            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.


            //CSS
            bundles.Add(new StyleBundle("~/bundles/lib/corecss").Include(
                    "~/Scripts/lib/bootstrap/css/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/bundles/lib/externalcss").Include(
                     "~/Scripts/lib/font-awesome/css/font-awesome.css",
                     "~/Content/css/zabuto_calendar.css",
                     "~/Scripts/lib/gritter/css/jquery.gritter.css",
                     "~/Scripts/lib/advanced-datatable/css/demo_page.css",
                     "~/Scripts/lib/advanced-datatable/css/demo_table.css",
                     "~/Scripts/lib/advanced-datatable/css/DT_bootstrap.css",
                     "~/Scripts/lib/bootstrap-fileupload/bootstrap-fileupload.css",
                      "~/Scripts/lib/fancybox/jquery.fancybox.css",
                      "~/Scripts/lib/bootstrap-datepicker/css/datepicker.css",
                      "~/Scripts/lib/bootstrap-daterangepicker/daterangepicker.css",
                      "~/Scripts/lib/bootstrap-timepicker/compiled/timepicker.css",
                      "~/Scripts/lib/bootstrap-datetimepicker/datertimepicker.css"));

            bundles.Add(new StyleBundle("~/bundles/css1").Include(
                      "~/Content/css/style.css",
                       "~/Content/css/style-responsive.css"));

        }
    }
}
