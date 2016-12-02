using System;

namespace MassTransit3TestFarm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceBusHelperFactory.CreateGatewayToFarmBus();

            Console.Read();
        }
    }
}
