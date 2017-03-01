using Minduca.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minduca.Domain.Payments
{
    public class Payment
    {
        public int Id { get; set; }

        /// <summary>
        /// Amount of money
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Order related to the payment
        /// </summary>
        public int OrderId { get; set; }
    }
}
