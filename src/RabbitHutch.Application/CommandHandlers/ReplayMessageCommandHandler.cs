using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RabbitHutch.Application.ServiceBusTechnologies;
using RabbitHutch.Domain;
using RabbitMQ.Client;

namespace RabbitHutch.Application.CommandHandlers
{
    public class ReplayMessageCommand : IRequest<ReplayMessageCommandResult>
    {
        public MessageDocument MessageDocument { get; set; }
        public string ReplayMessageBody { get; set; }
    }

    public class ReplayMessageCommandHandler : IRequestHandler<ReplayMessageCommand, ReplayMessageCommandResult>
    {
        public ReplayMessageCommandResult Handle(ReplayMessageCommand cmd)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var conn = factory.CreateConnection())
            using (var channel = conn.CreateModel())
            {
                var parser = MessageParserFactory.GetMessageDocumentParser(cmd.MessageDocument);

                var messageBodyBytes = System.Text.Encoding.UTF8.GetBytes(cmd.ReplayMessageBody);
                var basicProps = GetBasicProperties(channel.CreateBasicProperties(), cmd.MessageDocument, parser);

                channel.BasicPublish("", parser.ProcessingEndPoint, basicProps, messageBodyBytes);
            }

            return new ReplayMessageCommandResult { Success = true };
        }

        public Task<ReplayMessageCommandResult> Handle(ReplayMessageCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private IBasicProperties GetBasicProperties(IBasicProperties basicProps, MessageDocument document, IMessageParser parser)
        {
            basicProps.ContentType = "application/json";
            basicProps.DeliveryMode = 2;
            basicProps.MessageId = parser.MessageId;
            basicProps.CorrelationId = parser.MessageId;
            basicProps.Type = parser.MessageTypes;
            basicProps.Headers = new Dictionary<string, object>
            {
                {"RabbitHutch.IsReplay", "true"},
                {"RabbitHutch.ReplayDateTime", $"{DateTime.UtcNow:u}"},
            };

            return basicProps;
        }
    }

    public class ReplayMessageCommandResult
    {
        public bool Success { get; set; }
    }
}
