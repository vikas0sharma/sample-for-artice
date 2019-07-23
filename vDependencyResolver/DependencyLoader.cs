using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Reflection;
using System.Text;

namespace vDependencyResolver
{
    public static class DependencyLoader
    {
        public static void LoadDependencies(this IServiceCollection serviceCollection, string path, string pattern)
        {
            var dirCat = new DirectoryCatalog(path, pattern);
            var importDef = BuildImportDefinition();
            try
            {
                using (var aggregateCatalog = new AggregateCatalog())
                {
                    aggregateCatalog.Catalogs.Add(dirCat);

                    using (var componsitionContainer = new CompositionContainer(aggregateCatalog))
                    {
                        IEnumerable<Export> exports = componsitionContainer.GetExports(importDef);

                        IEnumerable<IDependencyResolver> modules =
                            exports.Select(export => export.Value as IDependencyResolver).Where(m => m != null);

                        var registerComponent = new DependencyRegister(serviceCollection);
                        foreach (IDependencyResolver module in modules)
                        {
                            module.SetUp(registerComponent);
                        }
                    }
                }
            }
            catch (ReflectionTypeLoadException typeLoadException)
            {
                var builder = new StringBuilder();
                foreach (Exception loaderException in typeLoadException.LoaderExceptions)
                {
                    builder.AppendFormat("{0}\n", loaderException.Message);
                }

                throw new TypeLoadException(builder.ToString(), typeLoadException);
            }
        }

        private static ImportDefinition BuildImportDefinition()
        {
            return new ImportDefinition(
                def => true, typeof(IDependencyResolver).FullName, ImportCardinality.ZeroOrMore, false, false);
        }
    }
}
