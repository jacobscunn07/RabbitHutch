using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using RabbitHutch.Application.CommandHandlers;
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

        public async Task<HttpResponseMessage> Get(long id)
        {
            try
            {
                var result = await _mediator.Send(new MessageDocumentQuery { DocumentId = id });

                var msg = new MessageResult
                {
                    DocumentId = result.MessageDocument.DocId,
                    Body = result.MessageDocument.Body,
                    Headers = result.MessageDocument.Headers.Select(x => new { x.Key, x.Value }).Where(x => !x.Key.StartsWith("$")).ToList(),
                    ServiceBusTechnology = result.MessageDocument.ServiceBusTechnology,
                    Replays = result.MessageDocument.Replays.Select(x => new MessageResult
                    {
                        DocumentId = x.DocId,
                        Body = x.Body,
                        Headers = x.Headers.Select(h => new { h.Key, h.Value }).Where(h => !h.Key.StartsWith("$")).ToList(),
                        ServiceBusTechnology = x.ServiceBusTechnology
                    })
                };

                return Request.CreateResponse(HttpStatusCode.OK, msg);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.PreconditionFailed, e.Message);
            }
        }
    }
}
