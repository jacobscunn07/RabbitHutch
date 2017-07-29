using MediatR;
using StructureMap;

namespace RabbitHutch.Host
{
    public class RabbitHutchRegistry : Registry
    {
        public RabbitHutchRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
                scan.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<>));
                scan.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>));
                scan.ConnectImplementationsToTypesClosing(typeof(IAsyncRequestHandler<>));
                scan.ConnectImplementationsToTypesClosing(typeof(IAsyncRequestHandler<,>));
                scan.ConnectImplementationsToTypesClosing(typeof(INotificationHandler<>));
                scan.ConnectImplementationsToTypesClosing(typeof(IAsyncNotificationHandler<>));
            });
            For<SingleInstanceFactory>().Use<SingleInstanceFactory>(ctx => t => ctx.GetInstance(t));
            For<MultiInstanceFactory>().Use<MultiInstanceFactory>(ctx => t => ctx.GetAllInstances(t));
            For<IMediator>().Use<Mediator>();
        }
    }
}
