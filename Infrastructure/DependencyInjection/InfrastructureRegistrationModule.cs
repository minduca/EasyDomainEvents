using Microsoft.Practices.Unity;
using Minduca.Application.Inventory;
using Minduca.Application.Orders;
using Minduca.Application.Payments;
using Minduca.Domain.Core.Data;
using Minduca.Domain.Core.Message;
using Minduca.Domain.Inventory;
using Minduca.Domain.Orders;
using Minduca.Domain.Payments;
using Minduca.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minduca.Infrastructure.DependencyInjection
{
    /// <summary>
    /// Register infrastructure components required by the application
    /// </summary>
    class InfrastructureRegistrationModule : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType(typeof(IRepository<>), typeof(DummyRepository<>), new ContainerControlledLifetimeManager());
            Container.RegisterType<IUserNotifier, ConsoleUserNotifier>(new ContainerControlledLifetimeManager());

            //Domain services
            Container.RegisterType<IInventoryService, InventoryService>();
            Container.RegisterType<IOrderPlacementService, OrderPlacementService>();
            Container.RegisterType<IPaymentService, PaymentService>();

            //Conventions at the end because it requires assemblies to be loaded
            Container.RegisterTypes(new EventHandlersConvention());
        }
    }
}
