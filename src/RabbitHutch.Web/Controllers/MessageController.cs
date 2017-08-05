using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using RabbitHutch.Application.CommandHandlers;
using RabbitHutch.Domain;
using RabbitHutch.Web.Models;

namespace RabbitHutch.Web.Controllers
{
    public class MessageController : ApiController
    {
        private readonly IMediator _mediator;

        public MessageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<HttpResponseMessage> Get(Guid guid)
        {
            var result = await _mediator.Send(new MessageDocumentQuery {MessageId = guid});

            var msg = new MessageResult
            {
                Body = result.MessageDocument.Body,
                Headers = result.MessageDocument.Headers.Select(x=> new { x.Key, x.Value}).Where(x => !x.Key.StartsWith("$")).ToList(),
                ServiceBusTechnology = result.MessageDocument.ServiceBusTechnology
            };
            
            return Request.CreateResponse(HttpStatusCode.OK, msg);
        }
    }
}
