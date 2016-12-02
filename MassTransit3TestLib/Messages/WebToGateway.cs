using System;

using MassTransit3TestLib.Interfaces;

namespace MassTransit3TestLib.Messages
{
    public class WebToGateway : IApplicationRequest
    {
        public WebToGateway()
        {
            
        }

        public WebToGateway(string name, Guid correlatedGuid)
        {
            this.Name = name;
            this.CorrelationId = correlatedGuid;
        }

        public WebToGateway(IApplicationRequest applicationRequest)
        {
            this.CorrelationId = applicationRequest.CorrelationId;
            this.ClientConnectionId = applicationRequest.ClientConnectionId;
            this.ClientConnectionGroup = applicationRequest.ClientConnectionGroup;
            this.MessageType = applicationRequest.MessageType;
            this.Name = applicationRequest.Name;
            this.ParamsAsJson = applicationRequest.ParamsAsJson;
            this.TimeStamp = applicationRequest.TimeStamp;
        }

        public Guid CorrelationId { get; set; }

        public string ClientConnectionGroup { get; set; }

        public string ClientConnectionId { get; set; }

        public DateTime TimeStamp { get; set; }

        public string MessageType { get; set; }

        public string Name { get; set; }

        public string ParamsAsJson { get; set; }
    }
}
