using NServiceBus;
using RabbitHutch.TestHarness.Commands;
using System.Threading.Tasks;

namespace RabbitHutch.TestHarness.Handlers
{
    public class SendToSelfCommandHandler : IHandleMessages<SendToSelf>
    {
        public Task Handle(SendToSelf message, IMessageHandlerContext context)
        {
            throw new System.Exception("errorrrrr");
            return Task.FromResult(0);
        }
    }
}
