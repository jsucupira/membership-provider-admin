using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using Membership.Common.Extensibility;
using Membership.Implementations.AspNet;
using Membership.Implementations.AspNet.Extensibility;

namespace Membership.Business.Tests
{
    public static class MefLoader
    {
        public static object SynchronizationLock { get; } = new object();

        public static void Init()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            MefBase.SetContainer(new CompositionContainer(catalog, true));
        }

        public static void InitIdentityContainer()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetAssembly(typeof(MembershipImplementationsAspNetAssembly))));
            MefBase.SetContainer(new CompositionContainer(catalog, true));
        }
    }
}