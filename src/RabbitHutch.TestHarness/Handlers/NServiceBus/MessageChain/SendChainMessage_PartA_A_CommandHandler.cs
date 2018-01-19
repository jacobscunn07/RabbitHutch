using NServiceBus;
using RabbitHutch.TestHarness.Commands;
using System.Threading.Tasks;

namespace RabbitHutch.TestHarness.Handlers.NServiceBus.MessageChain
{
    public class SendChainMessage_PartA_A_CommandHandler : IHandleMessages<SendChainMessage_PartA_A>
    {
        public Task Handle(SendChainMessage_PartA_A message, IMessageHandlerContext context)
        {
            return Task.FromResult(0);
        }
    }
}
