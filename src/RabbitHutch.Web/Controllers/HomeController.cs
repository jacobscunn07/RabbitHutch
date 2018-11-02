using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RabbitHutch.Application.CommandHandlers;

namespace RabbitHutch.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public async Task<ActionResult> Index()
        {
            var search = await _mediator.Send(new DocumentSearchQuery {PageSize = 20, PageIndex = 1, QueryString = ""});

            return View();
        }
    }
}