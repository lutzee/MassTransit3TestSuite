using System;

using MassTransit;

namespace MassTransit3TestWeb
{
    internal static class ServiceBusHelperFactory
    {
        private static string rabbitMqServer = "rabbitmq://localhost/";
        private static string rabbitMqUsername = "guest";
        private static string rabbitMqPassword = "guest";
        private static IBusControl webserviceBus;

        public static IBus InitServiceBus()
        {
            webserviceBus = Bus.Factory.CreateUsingRabbitMq(
                sbc =>
                {
                    sbc.UseXmlSerializer();
                    var host = sbc.Host(new Uri("rabbitmq://localhost/"), h =>
                    {
                        h.Username(rabbitMqUsername);
                        h.Password(rabbitMqPassword);
                    });

                    sbc.ReceiveEndpoint(host, "ZZ_argon_web",
                        ep =>
                        {
                            ep.UseConcurrencyLimit(8);
                        });
                });

            webserviceBus.Start();

            return webserviceBus;
        }
    }
}