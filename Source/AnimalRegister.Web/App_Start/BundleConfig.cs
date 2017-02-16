using System.Web.Optimization;

namespace AnimalRegister.Web
{
    public static class BundleConfig
    {
        /// <summary>
        /// Adds new bundles to the application
        /// </summary>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            CreateVendorBundles(bundles);
            CreateApplicationBundles(bundles);
            CreateThemeBundles(bundles);
        }

        /// <summary>
        /// Adds vendor bundles
        /// </summary>
        private static void CreateVendorBundles(BundleCollection bundles)
        {
            // ~/bundles/app/vendor/css
            bundles.Add(
                new StyleBundle("~/bundles/app/vendor/css")
                    .Include("~/Content/themes/base/all.css", new CssRewriteUrlTransform())
                    .Include("~/Content/toastr.min.css", new CssRewriteUrlTransform())
                    .Include("~/Content/angular-moment-picker.min.css", new CssRewriteUrlTransform())
                );

            // ~/bundles/app/vendor/js
            bundles.Add(
                new ScriptBundle("~/bundles/app/vendor/js")
                    .Include(
                        "~/Abp/Framework/scripts/utils/ie10fix.js",
                        "~/Scripts/json2.min.js",

                        "~/Scripts/modernizr-2.8.3.js",

                        "~/Scripts/jquery-3.1.1.min.js",
                        "~/Scripts/jquery-ui-1.12.1.min.js",

                        "~/Scripts/bootstrap.min.js",

                        "~/Scripts/moment-with-locales.min.js",
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.blockUI.js",
                        "~/Scripts/toastr.min.js",

                        "~/Scripts/angular.min.js",
                        "~/Scripts/angular-resource.min.js",
                        "~/Scripts/angular-animate.min.js",
                        "~/Scripts/angular-sanitize.min.js",
                        "~/Scripts/angular-ui-router.min.js",
                        "~/Scripts/angular-ui/ui-bootstrap.min.js",
                        "~/Scripts/angular-ui/ui-bootstrap-tpls.min.js",
                        "~/Scripts/angular-ui/ui-utils.min.js",
                        "~/Scripts/angular-moment-picker/angular-moment-picker.min.js",

                        "~/Abp/Framework/scripts/abp.js",
                        "~/Abp/Framework/scripts/libs/abp.jquery.js",
                        "~/Abp/Framework/scripts/libs/abp.toastr.js",
                        "~/Abp/Framework/scripts/libs/abp.blockUI.js",
                        "~/Abp/Framework/scripts/libs/angularjs/abp.ng.js"
                    )
                );

        }

        /// <summary>
        /// Adds application bundles
        /// </summary>
        private static void CreateApplicationBundles(BundleCollection bundles)
        {
            //~/bundles/app/main/css
            bundles.Add(
                new StyleBundle("~/bundles/app/main/css")
                    .IncludeDirectory("~/App/Main", "*.css", true)
                );

            //~/bundles/app/main/js
            bundles.Add(
                new ScriptBundle("~/bundles/app/main/js")
                    .IncludeDirectory("~/App/Main", "*.js", true)
                );
        }

        /// <summary>
        /// Adds theme bundles
        /// </summary>
        private static void CreateThemeBundles(BundleCollection bundles)
        {
            // ~/bundles/app/theme/css
            bundles.Add(
                new StyleBundle("~/bundles/app/theme/css")
                    .Include(
                        "~/Content/themes/ubold/plugins/datatables/jquery.dataTables.min.css",
                        "~/Content/themes/ubold/plugins/datatables/buttons.bootstrap.min.css",
                        "~/Content/themes/ubold/plugins/datatables/responsive.bootstrap.min.css",
                        "~/Content/themes/ubold/plugins/datatables/dataTables.colVis.css",
                        "~/Content/themes/ubold/plugins/datatables/dataTables.bootstrap.min.css",
                        "~/Content/themes/ubold/css/bootstrap.min.css",
                        "~/Content/themes/ubold/css/core.css",
                        "~/Content/themes/ubold/css/components.css",
                        "~/Content/themes/ubold/css/icons.css",
                        "~/Content/themes/ubold/css/pages.css",
                        "~/Content/themes/ubold/css/menu.css",
                        "~/Content/themes/ubold/css/responsive.css"
                    )
                );

            //~/ bundles/app/themes/js
            bundles.Add(
                new ScriptBundle("~/bundles/app/theme/js")
                    .Include(
                       "~/Content/themes/ubold/js/jquery.nicescroll.js",
                       "~/Content/themes/ubold/js/jquery.scrollTo.js",
                       "~/Content/themes/ubold/plugins/datatables/jquery.dataTables.min.js",
                       "~/Content/themes/ubold/plugins/datatables/dataTables.bootstrap.js",
                       "~/Content/themes/ubold/plugins/datatables/dataTables.buttons.min.js",
                       "~/Content/themes/ubold/plugins/datatables/buttons.bootstrap.min.js",
                       "~/Content/themes/ubold/plugins/datatables/jszip.min.js",
                       "~/Content/themes/ubold/plugins/datatables/pdfmake.min.js",
                       "~/Content/themes/ubold/plugins/datatables/vfs_fonts.js",
                       "~/Content/themes/ubold/plugins/datatables/buttons.html5.min.js",
                       "~/Content/themes/ubold/plugins/datatables/buttons.print.min.js",
                       "~/Content/themes/ubold/plugins/datatables/dataTables.responsive.min.js",
                       "~/Content/themes/ubold/plugins/datatables/responsive.bootstrap.min.js",
                       "~/Content/themes/ubold/plugins/datatables/dataTables.colVis.js"
                    )
                );
        }
    }
}