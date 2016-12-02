using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransit3TestGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();

            var bus = ServiceBusHelperFactory.CreateWebToGatewayBus();

            Console.Read();
        }
    }
}
