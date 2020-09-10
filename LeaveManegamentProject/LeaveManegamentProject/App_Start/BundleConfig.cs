using System.Web;
using System.Web.Optimization;

namespace LeaveManegamentProject
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-2.1.4.min.js"
                       ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
                                    "~/Scripts/angular/angular.min.js",
                                   "~/Scripts/angular/angular-route.min.js",
                                   "~/Scripts/angular/angular-ui-router.js",
                                   "~/Scripts/angular/angular-ui-router.min.js",
                                   "~/Scripts/angular/angular-ui-bootstrap.js",
                                    "~/Scripts/notifIt.js",
                                    "~/Scripts/ngconfirm/angular.confirm.min.js",
                                    "~/Scripts/moment.js",
                                    "~/Scripts/bootstrap-datepicker.min.js",
                                    "~/Scripts/angular/angular.js"));
            bundles.Add(new ScriptBundle("~/bundles/fileuploadjs").Include(
                                 "~/Scripts/ng-file-upload-all.min.js",
                                 "~/Scripts/ng-file-upload-shim.min.js",
                                 "~/Scripts/ng-file-upload.min.js"
                                 ));
            bundles.Add(new ScriptBundle("~/bundles/angularapp").Include(
                        "~/AppScripts/LeaveApp.js",
                        "~/AppScripts/LeaveAppService.js",
                        "~/AppScripts/EmployeeDetail/EmployeeDetailController.js",
                        "~/AppScripts/Admin/AdminController.js",
                        "~/AppScripts/Admin/LeaveController.js",
                        "~/AppScripts/Admin/LeaveApprovalController.js",
                        "~/AppScripts/Absencename/AbsencenameController.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
