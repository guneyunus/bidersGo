using bidersGo.Application.Features.Commands.AdminCreate;
using bidersGo.Domain.Entities.Identity;
using bidersGoUI.Extentions;
using DevExtreme.AspNet.Data;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace bidersGoUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IMediator _mediator;
        private readonly UserManager<ApplicationUser> _userManager;
        public AdminController(IMediator mediator,UserManager<ApplicationUser> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
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

        public IActionResult GetUser(DataSourceLoadOptions loadOptions)
        {
            var data = _userManager.Users;
            return Ok(DataSourceLoader.Load(data, loadOptions));
        }

        public IActionResult Users()
        {
            return View();
        }
    }
}
