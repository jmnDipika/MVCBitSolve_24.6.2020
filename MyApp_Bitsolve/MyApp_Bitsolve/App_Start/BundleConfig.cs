using System.Web;
using System.Web.Optimization;

namespace MyApp_Bitsolve
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            //            "~/Scripts/jquery-ui-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.unobtrusive*",
            //            "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                       "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            bundles.Add(new StyleBundle("~/Bundles/css")
             .Include("~/Content/Template/plugins/fontawesome-free/css/all.min.css")
             .Include("~/Content/Template/plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css")
             .Include("~/Content/Template/plugins/icheck-bootstrap/icheck-bootstrap.min.css")
             .Include("~/Content/Template/plugins/jqvmap/jqvmap.min.css")
             .Include("~/Content/Template/dist/css/adminlte.min.css")
             .Include("~/Content/Template/plugins/overlayScrollbars/css/OverlayScrollbars.min.css")
             .Include("~/Content/Template/plugins/daterangepicker/daterangepicker.css")
             .Include("~/Content/Template/plugins/summernote/summernote-bs4.css")
             .Include("~/Content/fontawesome-all.min.css")
             .Include("~/Content/themes/base/jquery-ui.min.css")
             .Include("~/Content/themes/base/theme.css")
           );


            bundles.Add(new ScriptBundle("~/Bundles/js")
              .Include("~/Content/Template/plugins/jquery/jquery.min.js")
              .Include("~/Content/Template/plugins/jquery-ui/jquery-ui.min.js")
              .Include("~/Content/Template/plugins/bootstrap/js/bootstrap.bundle.min.js")
              .Include("~/Content/Template/plugins/chart.js/Chart.min.js")
              .Include("~/Content/Template/plugins/sparklines/sparkline.js")
              .Include("~/Content/Template/plugins/jqvmap/jquery.vmap.min.js")
              .Include("~/Content/Template/plugins/jqvmap/maps/jquery.vmap.usa.js")
              .Include("~/Content/Template/plugins/jquery-knob/jquery.knob.min.js")
              .Include("~/Content/Template/plugins/moment/moment.min.js")
              .Include("~/Content/Template/plugins/daterangepicker/daterangepicker.js")
              .Include("~/Content/Template/plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js")
              .Include("~/Content/Template/plugins/summernote/summernote-bs4.min.js")
              .Include("~/Content/Template/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js")
              .Include("~/Content/Template/dist/js/adminlte.js")
              .Include("~/Content/Template/dist/js/page/dashboard.js")
              );



            bundles.Add(new ScriptBundle("~/Bundles/jqueryval")
               .Include("~/Content/Template/plugins/jquery-validation/jquery.validate.min.js")
               .Include("~/Scripts/jquery.validate.unobtrusive.min.js")
                .Include("~/Scripts/jquery.unobtrusive-ajax.min.js")
                .Include("~/Scripts/notify.min.js")
               );


            BundleTable.EnableOptimizations = false;
            bundles.IgnoreList.Clear();

        }
    }
}