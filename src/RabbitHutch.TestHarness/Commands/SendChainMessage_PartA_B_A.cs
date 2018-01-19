using NServiceBus;

namespace RabbitHutch.TestHarness.Commands
{
    public class SendChainMessage_PartA_B_A : ICommand
    {
        public string Name { get; set; }
    }
}
