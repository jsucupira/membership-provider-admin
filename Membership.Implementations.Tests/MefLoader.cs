using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using Membership.Common.Extensibility;
using Membership.Implementations.AspNet;

namespace Membership.Implementations.Tests
{
    public static class MefLoader
    {
        public static void InitIdentityContainer()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetAssembly(typeof(MembershipImplementationsAspNetAssembly))));
            MefBase.SetContainer(new CompositionContainer(catalog, true));
        }
    }
}