using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minduca.Domain.Orders
{
    public class OrderItem
    {
        public int InventoryItemId { get; set; }

        public ushort Quantity { get; set; }
    }
}
