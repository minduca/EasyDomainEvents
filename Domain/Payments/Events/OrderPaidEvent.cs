using Minduca.Domain.Core.Events;
using Minduca.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minduca.Domain.Payments.Events
{
    public class OrderPaidEvent : IDomainEvent
    {
        public OrderPaidEvent(Payment payment, IEnumerable<OrderItem> orderItems)
        {
            Payment = payment;
            OrderItems = new List<OrderItem>(orderItems);
        }

        public Payment Payment { get; private set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
