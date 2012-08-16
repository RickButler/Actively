using System.Web;
using System.Web.Optimization;

namespace actively
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.*"));            
            bundles.Add(new ScriptBundle("~/bundles/jquerymobile").Include(
                        "~/Scripts/jquery.mobile*"));
            bundles.Add(new ScriptBundle("~/bundles/lopeway").Include(
             "~/Scripts/lopeway.*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include("~/Scripts/knockout-2.1.0*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));     

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include("~/Content/normalize.css",
                         "~/Content/jquery.mobile*","~/Content/Site.css" 
                       ));            
        }
    }
}