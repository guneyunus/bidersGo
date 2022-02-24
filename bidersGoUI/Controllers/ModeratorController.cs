using bidersGo.Application.Features.Commands.ModeratorCreate;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace bidersGoUI.Controllers
{
    public class ModeratorController : Controller
    {
        private readonly IMediator _mediator;
        public ModeratorController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RegisterModerator()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterModerator(ModeratorCreateCommandRequest request)
        {
            ModeratorCreateCommandResponse response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
