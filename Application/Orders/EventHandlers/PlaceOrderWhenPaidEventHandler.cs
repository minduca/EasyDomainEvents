using Minduca.Domain.Core.Events;
using Minduca.Domain.Orders;
using Minduca.Domain.Payments.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minduca.Application.Orders.EventHandlers
{
    public class PlaceOrderWhenPaidEventHandler : IHandles<OrderPaidEvent>
    {
        private readonly IOrderPlacementService _orderPlacement;

        public PlaceOrderWhenPaidEventHandler(IOrderPlacementService orderPlacement)
        {
            _orderPlacement = orderPlacement;
        }

        public bool Deferred { get { return false; } }

        public void Handle(OrderPaidEvent domainEvent)
        {
            System.Console.WriteLine("[Event] - PlaceOrderWhenPaidEventHandler.Handle(domainEvent)");
            _orderPlacement.PlaceOrder(domainEvent.Payment.OrderId);
        }
    }
}
