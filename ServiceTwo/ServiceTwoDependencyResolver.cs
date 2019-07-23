using ServiceContracts;
using System.ComponentModel.Composition;
using vDependencyResolver;

namespace ServiceTwo
{
    [Export(typeof(IDependencyResolver))]
    public class ServiceTwoDependencyResolver : IDependencyResolver
    {
        public void SetUp(IDependencyRegister dependencyRegister)
        {
            dependencyRegister.AddScoped<IDummyService2, DummyService2>();
        }
    }
}
