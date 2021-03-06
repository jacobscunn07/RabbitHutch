﻿using System;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RabbitHutch.Application.CommandHandlers;
using RabbitHutch.Application.ServiceBusTechnologies;
using RabbitHutch.Domain;
using RabbitHutch.Web.Models;

namespace RabbitHutch.Web.Controllers
{
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        private readonly IMediator _mediator;

        public MessageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var result = await _mediator.Send(new MessageDocumentQuery { MessageId = id });
                var parser = MessageParserFactory.GetMessageDocumentParser(result.MessageDocument);

                var msg = new MessageResult
                {
                    MessageId = parser.MessageId,
                    Body = parser.Body,
                    StackTrace = parser.StackTrace,
                    Headers = parser.Headers.Select(x => new { x.Key, x.Value }).Where(x => !x.Key.StartsWith("$")).ToList(),
                    ServiceBusTechnology = parser.ServiceBusTechnology,
                    Replays = result.MessageDocument.Replays.Select(ParseReplay)
                };

                return Ok(msg);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
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
