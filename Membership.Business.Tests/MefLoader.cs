using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using Membership.Common.Extensibility;
using Membership.Implementations.AspNet;

namespace Membership.Business.Tests
{
    public static class MefLoader
    {
        public static void Init()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            MefBase.SetContainer(new CompositionContainer(catalog, true));
        }

        public static void InitIdentityContainer()
        {
            string path = Path.GetFullPath(@"..\..\..\Dependencies\identity\");
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(path, "*.dll"));
            MefBase.SetContainer(new CompositionContainer(catalog, true));
            ApplicationDbContext.DeleteDatabase();
        }

        public static object SynchronizationLock { get; } = new object();
    }
}