using System;

using MassTransit;

namespace MassTransit3TestLib.Interfaces
{
    public interface IApplicationRequest : CorrelatedBy<Guid>
    {
        // Required by SignalR
        string ClientConnectionGroup { get; set; }

        // Required by SignalR
        string ClientConnectionId { get; set; }

        // Time of request or response
        DateTime TimeStamp { get; set; }

        // Internal routing
        string MessageType { get; set; }

        string Name { get; set; }

        // any additional (generic) parameters
        string ParamsAsJson { get; set; }
    }
}
