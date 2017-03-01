using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minduca.Domain.Orders
{
    public enum EOrderStatus
    {
        None = 0,
        Placed = 1,
        Shipped = 2,
        Delivered = 3
    }
}
