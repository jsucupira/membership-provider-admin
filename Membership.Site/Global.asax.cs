using System;
using System.ComponentModel.Composition.Hosting;
using System.Configuration;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Membership.Common.Extensibility;
using Membership.Implementations.AspNet.Extensibility;
using Membership.Implementations.Traditional.Extensibility;

namespace Membership.Site
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AggregateCatalog catalog = new AggregateCatalog();

            string membershipType = ConfigurationManager.AppSettings["MembershipType"];

            if (membershipType.Equals("Traditional", StringComparison.OrdinalIgnoreCase))
                catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetAssembly(typeof (MembershipImplementationsTraditionalAssembly))));
            else
                catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetAssembly(typeof (MembershipImplementationsAspNetAssembly))));

            MefBase.SetContainer(new CompositionContainer(catalog, true));
        }
    }
}