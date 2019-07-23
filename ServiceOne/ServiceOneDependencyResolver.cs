using ServiceContracts;
using System.ComponentModel.Composition;
using vDependencyResolver;

namespace ServiceOne
{
    [Export(typeof(IDependencyResolver))]
    public class ServiceOneDependencyResolver : IDependencyResolver
    {
        public void SetUp(IDependencyRegister dependencyRegister)
        {
            dependencyRegister.AddScoped<IDummyService1, DummyService1>();
        }
    }
}
