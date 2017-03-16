using System.Web;
using System.Web.Optimization;

namespace HelpWeb
{
    public class BundleConfig
    {
        // 有关 Bundling 的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

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

            // file-input
            bundles.Add(new StyleBundle("~/Content/bootstrap-fileinput/fileinput.css")
                .IncludeDirectory("~/Content/bootstrap-fileinput", "*.css", true));

            bundles.Add(new ScriptBundle("~/Content/bootstrap-fileinput/js/fileinput.js")
                .Include("~/Content/bootstrap-fileinput/js/fileinput.js")
                .Include("~/Content/bootstrap-fileinput/js/locales/zh.js")
                .Include("~/Content/bootstrap-fileinput/js/plugins/canvas-to-blob.js")
                .Include("~/Content/bootstrap-fileinput/js/plugins/purify.js")
                .Include("~/Content/bootstrap-fileinput/js/plugins/sortable.js"));

            // common js
            bundles.Add(new ScriptBundle("~/Scripts/common/common.js")
                .Include("~/Scripts/common/jquery-1.12.4.js")
                .Include("~/Scripts/common/jquery.jsRender.min.js")
                .Include("~/Scripts/common/jquery.plugin.js")
                .Include("~/Scripts/common/sea.js")
                .Include("~/Scripts/common/moment.js")
                .Include("~/Scripts/common/underscore.js")
                );

            var appResourceLessBundle = new Bundle("~/Content/app.less").
                IncludeDirectory("~/Content/less", "*.less", true);

            bundles.Add(appResourceLessBundle);
        }
    }
}