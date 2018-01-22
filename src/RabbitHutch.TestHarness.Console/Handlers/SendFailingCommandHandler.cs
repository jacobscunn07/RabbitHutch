using NServiceBus;
using RabbitHutch.TestHarness.Console.Commands;
using System.Threading.Tasks;

namespace RabbitHutch.TestHarness.Handlers
{
    public class SendFailingCommandHandler : IHandleMessages<SendFailingCommand>
    {
        public Task Handle(SendFailingCommand message, IMessageHandlerContext context)
        {
            throw new System.Exception("I threw an exception on purpose.");
        }
    }
}
