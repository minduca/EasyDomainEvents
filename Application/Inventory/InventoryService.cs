using Minduca.Domain.Core.Data;
using Minduca.Domain.Core.Events;
using Minduca.Domain.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minduca.Application.Inventory
{
    public class InventoryService : IInventoryService
    {
        private readonly IDomainEventsRaiser _events;
        private readonly IRepository<InventoryItem> _inventoryItemRepository;

        public InventoryService(IRepository<InventoryItem> inventoryItemRepository, IDomainEventsRaiser events)
        {
            _inventoryItemRepository = inventoryItemRepository;
            _events = events;
        }

        public void SubtractAvailability(int itemId, ushort quantity)
        {
            System.Console.WriteLine("1.03 - InventoryService.SubtractAvailability(itemId:{0}, quantity:{1})", itemId, quantity);

            InventoryItem item = _inventoryItemRepository.GetById(itemId);
            item.Availability -= quantity;
            _inventoryItemRepository.Update(item);
        }
    }
}
