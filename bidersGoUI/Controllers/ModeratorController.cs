using bidersGo.Application.Features.Commands.ModeratorCreate;
using bidersGo.Application.Interfaces.UnitOfWork;
using bidersGoUI.Extentions;
using DevExtreme.AspNet.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace bidersGoUI.Controllers
{
    public class ModeratorController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        public ModeratorController(IMediator mediator,IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
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

        [HttpGet]
        public IActionResult GetModerator(DataSourceLoadOptions loadOptions)
        {
            var data = _unitOfWork.ModeratorRepository.GetModeratorAll();
            return Ok(DataSourceLoader.Load(data, loadOptions));
        }

        public IActionResult Moderators()
        {
            return View();
        }
    }
}
