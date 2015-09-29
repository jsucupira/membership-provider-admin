using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using Membership.Common.Extensibility;

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
    }
}