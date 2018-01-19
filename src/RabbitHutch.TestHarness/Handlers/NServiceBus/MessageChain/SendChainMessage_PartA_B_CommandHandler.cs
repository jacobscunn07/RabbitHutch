using NServiceBus;
using RabbitHutch.TestHarness.Commands;
using System.Threading.Tasks;

namespace RabbitHutch.TestHarness.Handlers.NServiceBus.MessageChain
{
    public class SendChainMessage_PartA_B_CommandHandler : IHandleMessages<SendChainMessage_PartA_B>
    {
        public Task Handle(SendChainMessage_PartA_B message, IMessageHandlerContext context)
        {
            context.SendLocal(new SendChainMessage_PartA_B_A { Name = "Blah" });
            return Task.FromResult(0);
        }
    }
}
