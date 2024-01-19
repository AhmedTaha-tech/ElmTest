using System.Reflection;

namespace Elm.Books.Api.Extentions
{
    public static class ConfigureServiceContainer
    {
        public static void AddMediatRService(this IServiceCollection services)
        {
            LoadAssemblies().ToList().ForEach(assembly => services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly)));
        }
        public static Assembly[] LoadAssemblies()
        {
            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            var loadedPaths = loadedAssemblies.Where(a => !a.IsDynamic).Select(a => a.Location).ToArray();
            var referencedPaths = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll");
            var toLoad = referencedPaths.Where(r => !loadedPaths.Contains(r, StringComparer.InvariantCultureIgnoreCase)).ToList();
            toLoad.ForEach(path => loadedAssemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(path))));

            var assemblies = loadedAssemblies.Where(a => a.FullName?.Contains("Elm.Books") == true).ToArray();
            return assemblies;
        }
    }
}
