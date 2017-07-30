using MediatR;
using RabbitHutch.Host.DataAccess;
using RabbitHutch.Host.Domain;
using RabbitMQ.Client.Events;
using System.Collections.Generic;

namespace RabbitHutch.Host.Application.CommandHandlers
{
    public class HandleMessageCommand : IRequest<HandleMessageCommandResult>
    {
        public BasicDeliverEventArgs DeliveryArgs { get; set; }
    }

    public class HandleMessageCommandHandler : IRequestHandler<HandleMessageCommand, HandleMessageCommandResult>
    {
        private readonly IDatabase _database;

        public HandleMessageCommandHandler(IDatabase database)
        {
            _database = database;
        }

        public HandleMessageCommandResult Handle(HandleMessageCommand cmd)
        {
            var msg = new RawMessage(cmd.DeliveryArgs);

            var messageDocumentBuilder = new MessageDocumentBuilder();
            var messageDocument =
                messageDocumentBuilder
                    .WithHeaders(msg.Headers)
                    .WithBody(msg.Body)
                    .WithBusTechnology(msg.BusTechnology)
                    .WithApplication(GetValueFromHeaders(ServiceBusTechnologies.NServiceBus.Headers.OriginatingEndPoint, msg.Headers))
                    .WithMessageTypes(GetValueFromHeaders(ServiceBusTechnologies.NServiceBus.Headers.EnclosedMessageTypes, msg.Headers))
                    .Finish();

            var success = _database.Insert(messageDocument);

            return new HandleMessageCommandResult { IsSuccessful = success, MessageDocument = messageDocument };
        }

        private string GetValueFromHeaders(string key, IDictionary<string, string> headers)
        {
            string val;
            headers.TryGetValue(key, out val);
            return val;
        }
    }

    public class HandleMessageCommandResult
    {
        public bool IsSuccessful { get; set; }
        public MessageDocument MessageDocument { get; set; }
    }
}
