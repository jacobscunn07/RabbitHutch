using NServiceBus;

namespace RabbitHutch.TestHarness.Console.Commands
{
    public class SendFailingCommand : ICommand
    {
        public string Name { get; set; }
    }
}
