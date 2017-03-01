using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minduca.Domain.Inventory
{
    /// <summary>
    /// Item from the inventory
    /// </summary>
    public class InventoryItem
    {
        public int Id { get; set; }

        /// <summary>
        /// Number of items available
        /// </summary>
        public int Availability { get; set; }

        /// <summary>
        /// Item name
        /// </summary>
        public string DisplayName { get; set; }
    }
}
