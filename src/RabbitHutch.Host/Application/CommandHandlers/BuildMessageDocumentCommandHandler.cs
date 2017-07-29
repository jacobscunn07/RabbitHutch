using MediatR;
using RabbitHutch.Host.Domain;
using System.Collections.Generic;

namespace RabbitHutch.Host.Application.CommandHandlers
{
    public class BuildMessageDocumentCommand : IRequest<BuildMessageDocumentCommandResult>
    {
        public IRawMessage RawMessage { get; set; }
    }

    public class BuildMessageDocumentCommandHandler : IRequestHandler<BuildMessageDocumentCommand, BuildMessageDocumentCommandResult>
    {
        public BuildMessageDocumentCommandResult Handle(BuildMessageDocumentCommand cmd)
        {
            var msg = cmd.RawMessage;
            var messageDocumentBuilder = new MessageDocumentBuilder();
            var messageDocument =
                messageDocumentBuilder
                    .WithHeaders(msg.Headers)
                    .WithBody(msg.Body)
                    .WithBusTechnology(msg.BusTechnology)
                    .WithApplication(GetValueFromHeaders(ServiceBusTechnologies.NServiceBus.Headers.OriginatingEndPoint, msg.Headers))
                    .WithMessageTypes(GetValueFromHeaders(ServiceBusTechnologies.NServiceBus.Headers.EnclosedMessageTypes, msg.Headers))
                    .Finish();

            return new BuildMessageDocumentCommandResult
            {
                MessageDocument = messageDocument
            };
        }

        public string GetValueFromHeaders(string key, IDictionary<string, string> headers)
        {
            string val;
            headers.TryGetValue(key, out val);
            return val;
        }
    }

    public class BuildMessageDocumentCommandResult
    {
        public MessageDocument MessageDocument { get; set; }
    }
}
