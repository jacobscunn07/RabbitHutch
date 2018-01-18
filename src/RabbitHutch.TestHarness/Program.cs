using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using RabbitHutch.TestHarness.MenuItems;

namespace RabbitHutch.TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncMain().GetAwaiter().GetResult();
        }

        static async Task AsyncMain()
        {
            var menuitems = Assembly.GetExecutingAssembly().DefinedTypes
                .Where(x => typeof(IMenuItem).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(x => Activator.CreateInstance(x.AsType()) as IMenuItem).ToList();

            while(true)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Key\tService Bus\tName");
                foreach (var menuItem in menuitems)
                {
                    Console.WriteLine($"{menuItem.Key}\t{menuItem.ServiceBus}\t{menuItem.Name}");
                }
                Console.WriteLine();
                Console.WriteLine("Enter key for menu item to be executed.");
                var selection = Console.ReadLine();
                if(!string.IsNullOrEmpty(selection))
                {
                    var menuItem = menuitems.Single(x => x.Key == selection);
                    await menuItem.ExecuteAsync();
                }
            }
        }
    }
}
