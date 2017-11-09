using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using RabbitHutch.Application.CommandHandlers;
using RabbitHutch.Application.ServiceBusTechnologies;
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

        public async Task<HttpResponseMessage> Get(long id)
        {
            try
            {
                var result = await _mediator.Send(new MessageDocumentQuery { DocumentId = id });
                var parser = MessageParserFactory.GetMessageDocumentParser(result.MessageDocument);

                var msg = new MessageResult
                {
                    MessageId = parser.MessageId,
                    DocumentId = result.MessageDocument.DocId,
                    Body = parser.Body,
                    StackTrace = parser.StackTrace,
                    Headers = parser.Headers.Select(x => new { x.Key, x.Value }).Where(x => !x.Key.StartsWith("$")).ToList(),
                    ServiceBusTechnology = parser.ServiceBusTechnology,
                    Replays = result.MessageDocument.Replays.Select(ParseReplay)
                };

                return Request.CreateResponse(HttpStatusCode.OK, msg);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.PreconditionFailed, e.Message);
            }
        }

        private static MessageResult.MessageReplayResult ParseReplay(MessageDocument document)
        {
            var parser = MessageParserFactory.GetMessageDocumentParser(document);

            return new MessageResult.MessageReplayResult
            {
                ReplayDateTime = parser.ReplayDateTime,
                IsError = parser.IsError
            };
        }
    }
}
