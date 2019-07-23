using ServiceContracts;
using System.ComponentModel.Composition;
using vDependencyResolver;

namespace NewService
{
    [Export(typeof(IDependencyResolver))]
    public class ServiceDependencyResolver : IDependencyResolver
    {
        public void SetUp(IDependencyRegister dependencyRegister)
        {
            dependencyRegister.AddScoped<IDummyService1, NewService>();
        }
    }
}
