using NServiceBus;

namespace RabbitHutch.TestHarness.Commands
{
    public class SendChainMessage_PartA_B : ICommand
    {
        public string Name { get; set; }
    }
}
