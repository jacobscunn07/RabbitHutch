using System;
using StructureMap;
using RabbitHutch.Host.Application;

namespace RabbitHutch.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = Container.For<RabbitHutchRegistry>();

            var app = container.GetInstance<Queue>();
            app.Run();
            Console.ReadLine();
        }
    }
}
