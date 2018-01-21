using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitHutch.TestHarness.Console.Commands
{
    public class SendSuccessfulCommand : ICommand
    {
        public string Name { get; set; }
    }
}
