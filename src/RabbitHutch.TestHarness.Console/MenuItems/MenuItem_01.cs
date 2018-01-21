using System.Threading.Tasks;

namespace RabbitHutch.TestHarness.Console.MenuItems
{
    public class MenuItem_01 : MenuItem
    {
        public MenuItem_01(ITest test) : base(test: test, name: "Send Successful Message", key: "01", servicebus: "NServiceBus")
        {
        }

        public override async Task ExecuteAsync()
        {
            System.Console.WriteLine("Inside Menu Item 01");
        }
    }
}
