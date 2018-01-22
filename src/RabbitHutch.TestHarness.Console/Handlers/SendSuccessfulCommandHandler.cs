using NServiceBus;
using RabbitHutch.TestHarness.Console.Commands;
using System.Threading.Tasks;

namespace RabbitHutch.TestHarness.Handlers
{
    public class SendSuccessfulCommandHandler : IHandleMessages<SendSuccessfulCommand>
    {
        public Task Handle(SendSuccessfulCommand message, IMessageHandlerContext context)
        {
            return Task.FromResult(0);
        }
    }
}
