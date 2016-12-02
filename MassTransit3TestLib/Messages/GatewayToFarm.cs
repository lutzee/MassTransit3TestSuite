using System;

using MassTransit;

using MassTransit3TestLib.Interfaces;

namespace MassTransit3TestLib.Messages
{
    public class GatewayToFarm : CorrelatedBy<Guid>, IDistributedRequest
    {
        public string MessageType { get; set; }

        public IApplicationRequest OriginalRequest { get; set; }

        public Guid CorrelationId { get; set; }
    }
}
