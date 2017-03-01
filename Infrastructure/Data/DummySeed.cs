using Minduca.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minduca.Domain.Core.Data;
using Minduca.Domain.Inventory;

namespace Minduca.Infrastructure.Data
{
    /// <summary>
    /// Insert some dummy data into the database
    /// </summary>
    class DummySeed
    {
        private IRepository<Order> _orderRepository;
        private IRepository<InventoryItem> _inventoryItemRepository;

        public DummySeed(IRepository<Order> orderRepository, IRepository<InventoryItem> inventoryItemRepository)
        {
            _orderRepository = orderRepository;
            _inventoryItemRepository = inventoryItemRepository;
        }

        public void Seed()
        {
            IEnumerable<InventoryItem> items = new List<InventoryItem>()
            {
                new InventoryItem { DisplayName = "Nice Shoes", Availability = 10 },
                new InventoryItem { DisplayName = "Freaking cool jeans", Availability = 10 },
                new InventoryItem { DisplayName = "Awesome book", Availability = 10 },
            };

            foreach (var item in items)
                item.Id = _inventoryItemRepository.Insert(item);

            Order order = new Order()
            {
                Items = new List<OrderItem>()
                {
                    new OrderItem { Quantity = 5, InventoryItemId = 1 },
                    new OrderItem { Quantity = 6, InventoryItemId = 2 },
                    new OrderItem { Quantity = 7, InventoryItemId = 3  }
                }
            };

            order.Id = _orderRepository.Insert(order);
        }
    }
}
