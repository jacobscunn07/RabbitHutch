using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RabbitHutch.Application.CommandHandlers;
using RabbitHutch.Web.Models;

namespace RabbitHutch.Web.Controllers
{
    public class ReplayController : Controller
    {
        private readonly IMediator _mediator;

        public ReplayController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ReplayRequest request)
        {
            try
            {
                var doc = await _mediator.Send(new MessageDocumentQuery { MessageId = request.MessageId });
                var isReplayed = await _mediator.Send(new ReplayMessageCommand { MessageDocument = doc.MessageDocument, ReplayMessageBody = request.Message });
                return this.Ok(isReplayed);
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }
    }
}
