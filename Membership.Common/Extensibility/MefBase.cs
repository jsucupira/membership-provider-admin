using System.ComponentModel.Composition.Hosting;

namespace Membership.Common.Extensibility
{
    public static class MefBase
    {
        private static ExportProvider _container;

        public static void SetContainer(CompositionContainer container)
        {
            _container = container;
        }

        public static T Resolve<T>()
        {
            return _container.ResolveExportedValue<T>();
        }
    }
}