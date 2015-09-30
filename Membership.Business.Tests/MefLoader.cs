using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using Membership.Common.Extensibility;
using Membership.Implementations.AspNet.Extensibility;
using Membership.Implementations.Traditional.Extensibility;

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

        public static void Init(IntegrationEnum integration)
        {
            AggregateCatalog catalog = new AggregateCatalog();

            catalog.Catalogs.Add(integration == IntegrationEnum.IdentityProvider
                ? new AssemblyCatalog(Assembly.GetAssembly(typeof (MembershipImplementationsAspNetAssembly)))
                : new AssemblyCatalog(Assembly.GetAssembly(typeof (MembershipImplementationsTraditionalAssembly))));

            MefBase.SetContainer(new CompositionContainer(catalog, true));
        }
    }

    public enum IntegrationEnum
    {
        IdentityProvider,
        MembershipProvider
    }
}