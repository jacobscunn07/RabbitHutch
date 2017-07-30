using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RabbitHutch.Host.Application
{
    public class Host : IHost
    {
        private readonly IMediator _mediator;

        public Host(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void Start()
        {
            var auditSettings = new QueueSettings("audit");
            var errorSettings = new QueueSettings("error");
            var testSettings = new QueueSettings("Autobahn.Configuration.Host");

            var audit = new Queue(_mediator, auditSettings);
            var error = new Queue(_mediator, errorSettings);
            var test = new Queue(_mediator, testSettings);

            var queues = new List<IQueue> { audit, error, test };

            Task.Factory.StartNew(() => Parallel.ForEach(queues, queue => queue.Run()));
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
