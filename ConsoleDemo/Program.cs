using Minduca.Domain.Orders;
using Minduca.Domain.Payments;
using Minduca.Infrastructure;
using System;

namespace Minduca.ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IScopeFactory scopeFactory = InfraConfig.Initialize();

            using (IAppLayer app = scopeFactory.CreateAppLayer())
            {
                IPaymentService payment = app.GetService<IPaymentService>();
                IOrderPlacementService orderPlacement = app.GetService<IOrderPlacementService>();

                Console.WriteLine("\n#### IPaymentService.PayOrder ####\n");
                payment.PayOrder(orderId: 1, amount: 30);
                app.UnitOfWork.Save();


                Console.WriteLine("\n#### IOrderPlacementService.ShipOrder ####\n");
                orderPlacement.ShipOrder(orderId: 1, address: "G1Q1Q9");
                app.UnitOfWork.Save();
            }

            Console.ReadKey();
        }
    }
}
