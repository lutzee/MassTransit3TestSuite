using System;

using MassTransit;
using MassTransit.Log4NetIntegration;
using MassTransit.Monitoring.Introspection.Contracts;

using MassTransit3TestLib.StaticHelpers;

namespace MassTransit3TestGateway
{
    internal static class ServiceBusHelperFactory
    {
        private static string rabbitMqServer = "rabbitmq://localhost/";
        private static string rabbitMqUsername = "guest";
        private static string rabbitMqPassword = "guest";

        public static IBus CreateWebToGatewayBus()
        {
            var sb = Bus.Factory.CreateUsingRabbitMq(
                        sbc =>
                        {
                            sbc.UseLog4Net();

                            var host = sbc.Host(new Uri(rabbitMqServer), h =>
                            {
                                h.Username(rabbitMqUsername);
                                h.Password(rabbitMqPassword);
                            });

                            sbc.ReceiveEndpoint(
                                host,
                                "ZZ_Web_To_Gateway_Queue",
                                ep =>
                                {
                                    ep.UseConcurrencyLimit(8);
                                    ep.UseRetry(Retry.None);

                                    ep.Consumer<GatewayConsumer>();
                                });
                            ConsoleHelper.WriteLine(rabbitMqServer + "ZZ_Web_To_Gateway_Queue");
                        });
            sb.Start();

            ProbeResult result = sb.GetProbeResult();

            ConsoleHelper.WriteDebugLine(result.ToJsonString());

            return sb;
        }
    }
}