using System;

using MassTransit;

using MassTransit3TestLib.Interfaces;

namespace MassTransit3TestLib.Messages
{
    public class FarmResponse : CorrelatedBy<Guid>, IDistributedRequest
    {
        public Guid CorrelationId { get; set; }

        public string MessageType { get; set; }

        public IApplicationRequest OriginalRequest { get; set; }
    }
}
