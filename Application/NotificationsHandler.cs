using Minduca.Domain.Core.Events;
using Minduca.Domain.Core.Message;
using Minduca.Domain.Orders.Events;
using Minduca.Domain.Payments.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minduca.BoundedContexts
{
    public class NotificationsHandler : IHandles<OrderPayedEvent>, IHandles<OrderShippedEvent> //<- multiple events handled by a single handler
    {
        private readonly IUserNotifier _notifier;

        public NotificationsHandler(IUserNotifier notifier) // <-- instantiated by the dependencies container
        {
            _notifier = notifier;
        }

        public bool Deferred { get { return true; } } //<- 'true' here indicates that all these events should be invoked only after the transaction is committed

        public void Handle(OrderPayedEvent domainEvent)
        {
            System.Console.WriteLine("[Event] - NotificationsHandler.Handle(domainEvent)");
            _notifier.Notify("Yay! We received your money. Your order has been placed");
        }

        public void Handle(OrderShippedEvent domainEvent)
        {
            System.Console.WriteLine("[Event] - NotificationsHandler.Handle(domainEvent)");
            _notifier.Notify(string.Format("Your order has finally been shipped. Address : \"{0}\"", domainEvent.Order.ShipmentAddress));
        }
    }
}
