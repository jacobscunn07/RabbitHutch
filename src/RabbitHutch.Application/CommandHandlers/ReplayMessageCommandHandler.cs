using System.Collections.Generic;
using MediatR;
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
                var messageBodyBytes = System.Text.Encoding.UTF8.GetBytes(cmd.MessageDocument.Body);
                var basicProps = channel.CreateBasicProperties();
                basicProps.ContentType = "text/plain";
                basicProps.DeliveryMode = 2;
                basicProps.Headers = new Dictionary<string, object> {{"RabbitHutch.IsReplay", true}};
                foreach (var header in cmd.MessageDocument.Headers)
                {
                    basicProps.Headers.Add(header.Key, header.Value);
                }

                channel.BasicPublish("",
                    "Autobahn.Ordering.Host", basicProps,
                    messageBodyBytes);
            }

            return new ReplayMessageCommandResult { Success = true };
        }
    }

    public class ReplayMessageCommandResult
    {
        public bool Success { get; set; }
    }
}
