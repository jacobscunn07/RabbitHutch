using NServiceBus;
using RabbitHutch.TestHarness.Commands;
using System.Threading.Tasks;

namespace RabbitHutch.TestHarness.Handlers.NServiceBus.MessageChain
{
    public class SendChainMessage_PartA_CommandHandler : IHandleMessages<SendChainMessage_PartA>
    {
        public Task Handle(SendChainMessage_PartA message, IMessageHandlerContext context)
        {
            context.SendLocal(new SendChainMessage_PartA_A { Name = "Blah" });
            context.SendLocal(new SendChainMessage_PartA_B { Name = "Blah" });
            return Task.FromResult(0);
        }
    }
}
