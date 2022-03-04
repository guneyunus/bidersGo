using bidersGo.Application.Features.Commands.AdminCreate;
using bidersGo.Application.Features.Commands.AdminDelete;
using bidersGo.Application.Features.Commands.AdminUpdate;
using bidersGo.Application.Features.Queries.AdminGetAll;
using bidersGo.Application.Interfaces.UnitOfWork;
using bidersGo.Domain.Entities.Identity;
using bidersGoUI.Extentions;
using DevExtreme.AspNet.Data;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using bidersGo.Application.Features.Commands.RolesAdded;

namespace bidersGoUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IMediator _mediator;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        public AdminController(IMediator mediator,UserManager<ApplicationUser> userManager,IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
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

        [HttpGet]
        public IActionResult GetAdmin(DataSourceLoadOptions loadOptions)
        {
            var data = _unitOfWork.AdminRepository.GetAdminAll();
            return Ok(DataSourceLoader.Load(data, loadOptions));
        }

        public IActionResult Admins()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateAdmin()
        {
            AdminGetAllQueryResponse response = await _mediator.Send(new AdminGetAllQueryRequest());
            ViewBag.Admin = response.AdminGetAll;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAdmin(AdminUpdateCommandRequest request)
        {
            AdminUpdateCommandResponse response = await _mediator.Send(request);

            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteAdmin()
        {
            AdminGetAllQueryResponse response = await _mediator.Send(new AdminGetAllQueryRequest());
            ViewBag.Admin1 = response.AdminGetAll;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAdmin(AdminDeleteCommandRequest request)
        {
            AdminDeleteCommandResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        public async Task<IActionResult> RoleAdd(RolesAddCommandRequest request)
        {
            RolesAddCommandResponse response = await _mediator.Send(request);

            return View(response);
        }
    }
}
