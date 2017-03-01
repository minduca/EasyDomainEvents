using Minduca.Domain.Core.Data;
using Minduca.Domain.Core.Events;
using Minduca.Domain.Orders;
using Minduca.Domain.Orders.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minduca.Application.Orders
{
    public class OrderPlacementService : IOrderPlacementService
    {
        private readonly IDomainEventsRaiser _events;
        private readonly IRepository<Order> _ordersRepository;

        public OrderPlacementService(IRepository<Order> ordersRepository, IDomainEventsRaiser events)
        {
            _ordersRepository = ordersRepository;
            _events = events;
        }

        public void PlaceOrder(int orderId)
        {
            System.Console.WriteLine("1.02 - OrderPlacementService.PlaceOrder(orderId:{0})", orderId);

            Order order = _ordersRepository.GetById(orderId);
            order.Status = EOrderStatus.Placed;
            _ordersRepository.Update(order);
        }

        public void ShipOrder(int orderId, string address)
        {
            System.Console.WriteLine("2.01 - OrderPlacementService.ShipOrder(orderId:{0}, address:{1})", orderId, address);

            Order order = _ordersRepository.GetById(orderId);
            order.Status = EOrderStatus.Shipped;
            order.ShipmentAddress = address;
            _ordersRepository.Update(order);

            _events.Raise(new OrderShippedEvent(order));
        }
    }
}
