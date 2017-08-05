using System;
using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using RabbitHutch.Application.CommandHandlers;

namespace RabbitHutch.Web.Controllers
{
    public class MessageController : ApiController
    {
        private readonly IMediator _mediator;

        public MessageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<MessageDocumentQueryResult> Get(Guid guid)
        {
            return await _mediator.Send(new MessageDocumentQuery {MessageId = guid});
        }
    }
}
