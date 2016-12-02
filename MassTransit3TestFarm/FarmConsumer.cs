using System;
using System.Threading.Tasks;

using MassTransit;

using MassTransit3TestLib.Messages;
using MassTransit3TestLib.StaticHelpers;

namespace MassTransit3TestFarm
{
    internal class FarmConsumer : IConsumer<SpecificReportGatewayToFarm>
    {
        public async Task Consume(ConsumeContext<SpecificReportGatewayToFarm> context)
        {
                        ConsoleHelper.WriteLine("Farm Receieved Message: " + context.Message.OriginalRequest.Name, ConsoleColor.Red);
                        ConsoleHelper.WriteLine("Message GUID: " + context.Message.OriginalRequest.CorrelationId, ConsoleColor.Red);
            await context.RespondAsync(new FarmResponse { OriginalRequest  = context.Message.OriginalRequest, CorrelationId = context.Message.CorrelationId });
        }
    }
}
