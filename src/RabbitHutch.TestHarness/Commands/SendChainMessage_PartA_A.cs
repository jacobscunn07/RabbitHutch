using NServiceBus;

namespace RabbitHutch.TestHarness.Commands
{
    public class SendChainMessage_PartA_A : ICommand
    {
        public string Name { get; set; }
    }
}
