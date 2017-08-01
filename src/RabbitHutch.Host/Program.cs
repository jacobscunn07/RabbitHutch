﻿using StructureMap;
using RabbitHutch.Host.Application;
using RabbitHutch.Host.Application.Interfaces;
using Topshelf;

namespace RabbitHutch.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = Container.For<RabbitHutchRegistry>();

            HostFactory.Run(x =>
            {
                x.Service<IHost>(s =>
                {
                    s.ConstructUsing(name => container.GetInstance<Application.Host>());
                    s.WhenStarted(host => host.Start());
                    s.WhenStopped(host => host.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("Scrapes messages from Rabbit Audit and Error Queues.");
                x.SetDisplayName("RabbitHutch Host");
                x.SetServiceName("RabbitHutch.Host");
                x.StartAutomatically();
            });
        }
    }
}
