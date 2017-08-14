using System;
using System.Collections.Generic;
using MediatR;
using RabbitHutch.Application.ServiceBusTechnologies;
using RabbitHutch.Domain;
using RabbitMQ.Client;

namespace RabbitHutch.Application.CommandHandlers
{
    public class ReplayMessageCommand : IRequest<ReplayMessageCommandResult>
    {
        public MessageDocument MessageDocument { get; set; }
    }

    public class ReplayMessageCommandHandler : IRequestHandler<ReplayMessageCommand, ReplayMessageCommandResult>
    {
        public ReplayMessageCommandResult Handle(ReplayMessageCommand cmd)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var conn = factory.CreateConnection())
            using (var channel = conn.CreateModel())
            {
                var messageParserFactory = new MessageParserFactory();
                var parser = messageParserFactory.GetMessageDocumentParser(cmd.MessageDocument);

                var messageBodyBytes = System.Text.Encoding.UTF8.GetBytes(cmd.MessageDocument.Body);
                var basicProps = GetBasicProperties(channel.CreateBasicProperties(), cmd.MessageDocument, parser);

                channel.BasicPublish("", parser.FailedQueue, basicProps, messageBodyBytes);
            }

            return new ReplayMessageCommandResult { Success = true };
        }

        private IBasicProperties GetBasicProperties(IBasicProperties basicProps, MessageDocument document, IMessageParser parser)
        {
            basicProps.ContentType = "text/plain";
            basicProps.DeliveryMode = 2;
            basicProps.MessageId = parser.MessageId;
            basicProps.CorrelationId = parser.MessageId;
            basicProps.Headers = new Dictionary<string, object>
            {
                {"RabbitHutch.IsReplay", "true"},
                {"RabbitHutch.ReplayDateTime", $"{DateTime.UtcNow:u}"},
            };
            foreach (var header in document.Headers)
            {
                basicProps.Headers.Add(header.Key, header.Value);
            }

            return basicProps;
        }
    }

    public class ReplayMessageCommandResult
    {
        public bool Success { get; set; }
    }
}
