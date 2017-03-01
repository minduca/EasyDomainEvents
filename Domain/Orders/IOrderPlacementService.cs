using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minduca.Domain.Orders
{
    public interface IOrderPlacementService
    {
        /// <summary>
        /// Places a order
        /// </summary>
        void PlaceOrder(int orderId);

        /// <summary>
        /// Ships the products related to the order
        /// </summary>
        void ShipOrder(int orderId, string address);
    }
}
