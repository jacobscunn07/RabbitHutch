using System;
using StructureMap;

namespace RabbitHutch.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = Container.For<RabbitHutchRegistry>();

            var app = container.GetInstance<App>();
            app.Run();
            Console.ReadLine();
        }
    }
}
