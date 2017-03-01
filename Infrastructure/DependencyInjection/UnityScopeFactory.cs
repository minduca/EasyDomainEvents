using Microsoft.Practices.Unity;
using Minduca.Domain.Core.Data;
using Minduca.Domain.Core.Events;
using Minduca.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minduca.Infrastructure.DependencyInjection
{
    /// <summary>
    /// Factory that creates the application layer
    /// </summary>
    class UnityScopeFactory : IScopeFactory
    {
        private readonly IUnityContainer _container;

        public UnityScopeFactory(IUnityContainer container)
        {
            _container = container;
        }

        public IAppLayer CreateAppLayer()
        {
            IUnityContainer childContainer = _container.CreateChildContainer();
            IServiceProvider containerProvider = new UnityServiceProvider(childContainer);

            childContainer.RegisterType<IDomainEventsRaiser, DeferredDomainEventsRaiser>(new ContainerControlledLifetimeManager());

            childContainer.RegisterType<DummyUnitOfWork>(new ContainerControlledLifetimeManager());
            childContainer.RegisterType<IUnitOfWork, DummyUnitOfWork>();
            childContainer.RegisterType<IDbStateTracker, DummyUnitOfWork>();
            childContainer.RegisterInstance<IServiceProvider>(containerProvider);

            return new AppLayer(containerProvider);
        }
    }
}
