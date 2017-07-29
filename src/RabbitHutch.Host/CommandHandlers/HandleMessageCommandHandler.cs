using MediatR;
using RabbitHutch.Host.Domain;
using RabbitMQ.Client.Events;

namespace RabbitHutch.Host.CommandHandlers
{
    public class HandleMessageCommand : IRequest<HandleMessageCommandResult>
    {
        public BasicDeliverEventArgs DeliveryArgs { get; set; }
    }

    public class HandleMessageCommandHandler : IRequestHandler<HandleMessageCommand, HandleMessageCommandResult>
    {
        public HandleMessageCommandResult Handle(HandleMessageCommand cmd)
        {
            var rawMessage = new RawMessage(cmd.DeliveryArgs);

            return new HandleMessageCommandResult { RawMessage = rawMessage };
        }
    }

    public class HandleMessageCommandResult
    {
        public IRawMessage RawMessage { get; set; }
    }
}
