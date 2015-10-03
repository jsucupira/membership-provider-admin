using System.Web;
using System.Web.Optimization;

namespace Membership.Site
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/app/models").IncludeDirectory("~/Scripts/app/models", "*.js"));
            bundles.Add(new ScriptBundle("~/bundles/app/helpers").IncludeDirectory("~/Scripts/app/helpers", "*.js"));
            bundles.Add(new ScriptBundle("~/bundles/app/services").IncludeDirectory("~/Scripts/app/services", "*.js"));
            bundles.Add(new ScriptBundle("~/bundles/app/controllers").IncludeDirectory("~/Scripts/app/controllers", "*.js"));
        }
    }
}
