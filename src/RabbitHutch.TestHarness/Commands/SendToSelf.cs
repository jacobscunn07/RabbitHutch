using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitHutch.TestHarness.Commands
{
    public class SendToSelf : ICommand
    {
        public string Name { get; set; }
    }
}
