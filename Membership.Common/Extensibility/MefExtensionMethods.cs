﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;

namespace Membership.Common.Extensibility
{
    public static class MefExtensionMethods
    {
        public static T ResolveExportedValue<T>(this ExportProvider container)
        {
            if (container == null)
                throw new Exception("MEF composition container is null.");

            IEnumerable<T> exports = container.GetExportedValues<T>();
            IEnumerable<T> enumerable = exports as T[] ?? exports.ToArray();
            if (enumerable.Count() == 1)
                return enumerable.First();
            if (!enumerable.Any())
                throw new Exception(string.Format("Could not resolve MEF Export for '{0}'.", typeof (T).Name));
            //TODO:  Consider adding meta data attributes to exports to allow selecting non "Default" if there are multiple exports found.
            //throw new Exception(string.Format("Could not resolve MEF Export for '{0}'. (multiple defaults)", typeof(T).Name));
            return enumerable.Last();
        }

        public static T ResolveExportedValue<T>(this ExportProvider container, string className)
        {
            if (container == null)
                throw new Exception("MEF composition container is null.");

            IEnumerable<T> exports = container.GetExportedValues<T>();
            IEnumerable<T> enumerable = exports as T[] ?? exports.ToArray();
            if (!enumerable.Any())
                throw new Exception(string.Format("Could not resolve MEF Export for '{0}'.", typeof(T).Name));
            foreach (T export in enumerable)
            {
                if (export.GetType().Name.Equals(className, StringComparison.InvariantCultureIgnoreCase))
                    return export;
            }
            throw new Exception(string.Format("Could not resolve MEF Export for '{0}' with class name '{1}'. (multiple exports)", typeof(T).Name, className));
        }
    }
}