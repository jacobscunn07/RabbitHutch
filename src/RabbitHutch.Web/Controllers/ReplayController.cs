using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using RabbitHutch.Application.CommandHandlers;
using RabbitHutch.Web.Models;

namespace RabbitHutch.Web.Controllers
{
    public class ReplayController : ApiController
    {
        private readonly IMediator _mediator;

        public ReplayController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody]ReplayRequest request)
        {
            try
            {
                var doc = await _mediator.Send(new MessageDocumentQuery { DocumentId = request.DocId });
                var isReplayed = await _mediator.Send(new ReplayMessageCommand { MessageDocument = doc.MessageDocument, ReplayMessageBody = request.Message });
                return Request.CreateResponse(HttpStatusCode.OK, isReplayed);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}
