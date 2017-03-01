using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minduca.Domain.Payments
{
    public interface IPaymentService
    {
        /// <summary>
        /// Pays an order
        /// </summary>
        void PayOrder(int orderId, decimal amount);
    }
}
