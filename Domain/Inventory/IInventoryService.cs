using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minduca.Domain.Inventory
{
    /// <summary>
    /// Services related to the inventory (items on the stock)
    /// </summary>
    public interface IInventoryService
    {
        void SubtractAvailability(int itemId, ushort quantity);
    }
}
