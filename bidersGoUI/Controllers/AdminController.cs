using bidersGo.Application.Features.Commands.AdminCreate;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace bidersGoUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IMediator _mediator;
        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult RegisterAdmin()
        {
            return View();
        }

        public async Task<IActionResult> RegisterAdmin(AdminCreateCommandRequest request)
        {
            AdminCreateCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
