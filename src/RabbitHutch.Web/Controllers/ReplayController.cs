using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using RabbitHutch.Application.CommandHandlers;

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
                //TODO: need to pass on new body to be part of replay
                var doc = await _mediator.Send(new MessageDocumentQuery { DocumentId = request.DocId });
                var isReplayed = await _mediator.Send(new ReplayMessageCommand { MessageDocument = doc.MessageDocument });
                return Request.CreateResponse(HttpStatusCode.OK, isReplayed);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        public class ReplayRequest
        {
            public long DocId { get; set; }
            public string Message { get; set; }
        }
    }
}
