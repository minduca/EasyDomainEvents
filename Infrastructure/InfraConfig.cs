using Microsoft.Practices.Unity;
using Minduca.Domain.Core.Data;
using Minduca.Domain.Core.Events;
using Minduca.Domain.Inventory;
using Minduca.Domain.Orders;
using Minduca.Infrastructure.Data;
using Minduca.Infrastructure.DependencyInjection;
using System;

namespace Minduca.Infrastructure
{
    /// <summary>
    /// Infrastructure initializer
    /// </summary>
    public static class InfraConfig
    {
        public static IScopeFactory Initialize()
        {
            UnityContainer container = LoadContainer();
            SeedDatabase(container);
            return new UnityScopeFactory(container);
        }

        private static UnityContainer LoadContainer()
        {
            UnityContainer container = new UnityContainer();

            container.AddNewExtension<InfrastructureRegistrationModule>();
            container.AddNewExtension<DomainServicesRegistrationModule>();
            container.RegisterTypes(new EventHandlersConvention());

            return container;
        }

        private static void SeedDatabase(UnityContainer container)
        {
            DummySeed seed = new DummySeed(container.Resolve<IRepository<Order>>(), container.Resolve<IRepository<InventoryItem>>());
            seed.Seed();
        }
    }
}
