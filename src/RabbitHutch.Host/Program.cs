using StructureMap;
using RabbitHutch.Host.Application;
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
                x.Service<IQueue>(s =>
                {
                    s.ConstructUsing(name => container.GetInstance<Queue>());
                    s.WhenStarted(queue => queue.Run());
                    s.WhenStopped(queue => queue.Stop());
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
