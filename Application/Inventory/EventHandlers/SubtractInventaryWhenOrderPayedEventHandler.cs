using Minduca.Domain.Core.Events;
using Minduca.Domain.Inventory;
using Minduca.Domain.Payments.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minduca.Application.Inventory.EventHandlers
{
    public class SubtractInventaryWhenOrderPayedEventHandler : IHandles<OrderPayedEvent>
    {
        private readonly IInventoryService _inventory;

        public SubtractInventaryWhenOrderPayedEventHandler(IInventoryService inventory)
        {
            _inventory = inventory;
        }

        public bool Deferred { get { return false; } }

        public void Handle(OrderPayedEvent domainEvent)
        {
            System.Console.WriteLine("[Event] - SubtractInventaryWhenOrderPayedEventHandler.Handle(domainEvent)");
            foreach (var item in domainEvent.OrderItems)
                _inventory.SubtractAvailability(item.InventoryItemId, item.Quantity);
        }
    }
}
