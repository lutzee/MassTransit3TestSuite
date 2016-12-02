using System;

using MassTransit3TestLib.Messages;
using MassTransit3TestLib.StaticHelpers;

namespace MassTransit3TestWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webBus = ServiceBusHelperFactory.InitServiceBus();

            var message = new WebToGateway { Name = "TestMessage", CorrelationId = Guid.NewGuid() };

            ConsoleHelper.WriteLine($"Sending message '{ message.Name }' with ID '{message.CorrelationId }'", ConsoleColor.Yellow);

            webBus.Publish(message);

            Console.Read();
        }
    }
}
