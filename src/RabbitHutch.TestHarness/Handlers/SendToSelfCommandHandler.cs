using NServiceBus;
using RabbitHutch.TestHarness.Commands;
using System.Threading.Tasks;

namespace RabbitHutch.TestHarness.Handlers
{
    public class SendToSelfCommandHandler : IHandleMessages<SendToSelf>
    {
        public Task Handle(SendToSelf message, IMessageHandlerContext context)
        {
            return Task.FromResult(0);
        }
    }
}
