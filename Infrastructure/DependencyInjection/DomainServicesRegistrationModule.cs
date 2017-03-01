using Microsoft.Practices.Unity;
using Minduca.Application.Inventory;
using Minduca.Application.Orders;
using Minduca.Application.Payments;
using Minduca.Domain.Inventory;
using Minduca.Domain.Orders;
using Minduca.Domain.Payments;

namespace Minduca.Infrastructure.DependencyInjection
{
    /// <summary>
    /// Register all the domain services
    /// </summary>
    class DomainServicesRegistrationModule : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IInventoryService, InventoryService>();
            Container.RegisterType<IOrderPlacementService, OrderPlacementService>();
            Container.RegisterType<IPaymentService, PaymentService>();
        }
    }
}
