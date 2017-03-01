using Microsoft.Practices.Unity;
using System;

namespace Minduca.Infrastructure.DependencyInjection
{
    /// <summary>
    /// Adapter that hides Unity dependencies
    /// </summary>
    class UnityServiceProvider : IServiceProvider
    {
        private readonly IUnityContainer _container;
        private readonly string _name;

        public UnityServiceProvider(IUnityContainer container, string name = null)
        {
            _container = container;
            _name = name;
        }

        public object GetService(Type serviceType)
        {
            return _container.Resolve(serviceType, _name);
        }
    }
}
