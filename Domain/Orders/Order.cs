using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minduca.Domain.Orders
{
    public class Order
    {
        public Order()
        {
            Items = new List<OrderItem>();
        }

        public int Id { get; set; }
        public EOrderStatus Status { get; set; }
        public string ShipmentAddress { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}
