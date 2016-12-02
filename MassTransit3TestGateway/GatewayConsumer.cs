using System;
using System.Threading.Tasks;

using MassTransit;

using MassTransit3TestLib.Messages;
using MassTransit3TestLib.StaticHelpers;

namespace MassTransit3TestGateway
{
    public class GatewayConsumer : IConsumer<WebToGateway>
    {
        public async Task Consume(ConsumeContext<WebToGateway> context)
        {
            ConsoleHelper.WriteLine($"Gateway received request to process message named '{context.Message.Name}'", ConsoleColor.Green);
            ConsoleHelper.WriteLine("Message GUID: " + context.Message.CorrelationId, ConsoleColor.Green);

            var downwardsMessage = new SpecificReportGatewayToFarm() { OriginalRequest = context.Message, CorrelationId = context.Message.CorrelationId };
            var uriExchange = new Uri("rabbitmq://localhost:5672/ZZ_Gateway_To_Farm_Queue");

            await context.Forward(uriExchange, downwardsMessage);
        }
    }
}
