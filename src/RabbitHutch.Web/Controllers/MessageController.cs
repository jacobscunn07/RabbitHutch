using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using RabbitHutch.Application.CommandHandlers;
using RabbitHutch.Domain;

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
            
            return Request.CreateResponse(HttpStatusCode.OK, result.MessageDocument);
        }
    }
}
