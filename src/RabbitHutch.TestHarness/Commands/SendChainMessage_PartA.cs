using NServiceBus;

namespace RabbitHutch.TestHarness.Commands
{
    public class SendChainMessage_PartA : ICommand
    {
        public string Name { get; set; }
    }
}
