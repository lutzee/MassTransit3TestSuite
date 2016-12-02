using System;

namespace MassTransit3TestLib.Interfaces
{
    public interface IDistributedRequest
    {
        Guid CorrelationId { get; set; }

        string MessageType { get; set; }

        IApplicationRequest OriginalRequest { get; set; }
    }
}
