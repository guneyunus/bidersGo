using bidersGo.Application.Features.Commands.RoleUpdate;
using bidersGo.Application.Features.Queries.RoleGetAll;
using bidersGo.Application.Features.Queries.UserGetAll;
using bidersGo.Application.Features.Queries.UserGetById;
using bidersGo.Application.Interfaces.UnitOfWork;
using bidersGo.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace bidersGoUI.Controllers
{
    public class RoleController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public RoleController(IMediator mediator,IUnitOfWork unitOfWork,RoleManager<ApplicationRole> roleManager,UserManager<ApplicationUser> userManager)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> RoleAssign()
        {
            UserGetAllQueryResponse response = await _mediator.Send(new UserGetAllQueryRequest());
            ViewBag.Users = response.UserGetAll;

            RoleGetAllQueryResponse responseRole = await _mediator.Send(new RoleGetAllQueryRequest());
            ViewBag.Roles = responseRole.GetAllRole;

            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RoleAssign(RoleUpdateCommandRequest request)
        {
            RoleUpdateCommandResponse response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
