using Minduca.Domain.Core.Data;
using Minduca.Domain.Core.Events;
using Minduca.Domain.Orders;
using Minduca.Domain.Payments;
using Minduca.Domain.Payments.Events;

namespace Minduca.Application.Payments
{
    public class PaymentService : IPaymentService
    {
        private readonly IDomainEventsRaiser _events;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Payment> _paymentRepository;

        public PaymentService(IRepository<Payment> paymentRepository, IRepository<Order> orderRepository, IDomainEventsRaiser events)
        {
            _paymentRepository = paymentRepository;
            _orderRepository = orderRepository;
            _events = events;
        }

        public void PayOrder(int orderId, decimal amount)
        {
            System.Console.WriteLine("1.01 - PaymentService.PayOrder(orderId:{0}, amount:{1})", orderId, amount);

            Order order = _orderRepository.GetById(orderId);

            Payment payment = new Payment()
            {
                OrderId = orderId,
                Amount = amount
            };

            _paymentRepository.Insert(payment);

            _events.Raise(new OrderPayedEvent(payment, order.Items));
        }
    }
}
