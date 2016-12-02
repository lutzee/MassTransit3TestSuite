using System;

using MassTransit;
using MassTransit.Log4NetIntegration;

using MassTransit3TestLib.StaticHelpers;

namespace MassTransit3TestFarm
{
    internal static class ServiceBusHelperFactory
    {
        private static string rabbitMqServer = "rabbitmq://localhost/";
        private static string rabbitMqUsername = "guest";
        private static string rabbitMqPassword = "guest";

        public static IBus CreateGatewayToFarmBus()
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
                                "ZZ_Gateway_To_Farm_Queue",
                                ep =>
                                {
                                    ep.UseConcurrencyLimit(8);
                                    ep.UseRetry(Retry.None);

                                    ep.Consumer<FarmConsumer>();
                                });

                            ConsoleHelper.WriteLine(rabbitMqServer + "ZZ_Gateway_To_Farm_Queue");
                        });

            sb.Start();

            return sb;
        }
    }
}