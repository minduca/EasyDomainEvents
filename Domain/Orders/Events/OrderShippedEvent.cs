using Minduca.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minduca.Domain.Orders.Events
{
    public class OrderShippedEvent : IDomainEvent
    {
        public OrderShippedEvent(Order order)
        {
            Order = order;
        }

        public Order Order { get; private set; }
    }
}
