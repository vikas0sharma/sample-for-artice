using Microsoft.Extensions.DependencyInjection;

namespace vDependencyResolver
{
    public class DependencyRegister : IDependencyRegister
    {
        private readonly IServiceCollection serviceCollection;

        public DependencyRegister(IServiceCollection serviceCollection)
        {
            this.serviceCollection = serviceCollection;
        }

        void IDependencyRegister.AddScoped<TService>()
        {
            serviceCollection.AddScoped<TService>();
        }

        void IDependencyRegister.AddScoped<TService, TImplementation>()
        {
            serviceCollection.AddScoped<TService, TImplementation>();
        }

        void IDependencyRegister.AddScopedForMultiImplementation<TService, TImplementation>()
        {
            serviceCollection.AddScoped<TImplementation>()
                .AddScoped<TService, TImplementation>(s => s.GetService<TImplementation>());
        }

        void IDependencyRegister.AddSingleton<TService>()
        {
            serviceCollection.AddSingleton<TService>();
        }

        void IDependencyRegister.AddSingleton<TService, TImplementation>()
        {
            serviceCollection.AddSingleton<TService, TImplementation>();
        }

        void IDependencyRegister.AddTransient<TService>()
        {
            serviceCollection.AddTransient<TService>();
        }

        void IDependencyRegister.AddTransient<TService, TImplementation>()
        {
            serviceCollection.AddTransient<TService, TImplementation>();
        }

        void IDependencyRegister.AddTransientForMultiImplementation<TService, TImplementation>()
        {
            serviceCollection.AddTransient<TImplementation>()
                .AddTransient<TService, TImplementation>(s => s.GetService<TImplementation>());
        }
    }
}
