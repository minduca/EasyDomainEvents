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
    public class PlaceOrderWhenPayedEventHandler : IHandles<OrderPayedEvent>
    {
        private readonly IOrderPlacementService _orderPlacement;

        public PlaceOrderWhenPayedEventHandler(IOrderPlacementService orderPlacement)
        {
            _orderPlacement = orderPlacement;
        }

        public bool Deferred { get { return false; } }

        public void Handle(OrderPayedEvent domainEvent)
        {
            System.Console.WriteLine("[Event] - PlaceOrderWhenPayedEventHandler.Handle(domainEvent)");
            _orderPlacement.PlaceOrder(domainEvent.Payment.OrderId);
        }
    }
}
