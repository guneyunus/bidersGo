using bidersGo.Application.Features.Commands.ModeratorCreate;
using bidersGo.Application.Features.Commands.ModeratorDelete;
using bidersGo.Application.Features.Commands.ModeratorUpdate;
using bidersGo.Application.Features.Queries.ModeratorGetAll;
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

        //[HttpGet]
        //public IActionResult RegisterModerator()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> RegisterModerator(ModeratorCreateCommandRequest request)
        //{
        //    ModeratorCreateCommandResponse response = await _mediator.Send(request);

        //    return Ok(response);
        //}

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
        [HttpGet]
        public async Task<IActionResult> DeleteModerator()
        {
            ModeratorGetAllQueryResponse response = await _mediator.Send(new ModeratorGetAllQueryRequest());
            ViewBag.Moderator1 = response.GetModeratorAll;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteModerator(ModeratorDeleteCommandRequest request)
        {
            ModeratorDeleteCommandResponse response = await _mediator.Send(request);

            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateModerator()
        {
            ModeratorGetAllQueryResponse response = await _mediator.Send(new ModeratorGetAllQueryRequest());
            ViewBag.Moderator = response.GetModeratorAll;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateModerator(ModeratorUpdateCommandRequest request)
        {
            ModeratorUpdateCommandResponse response = await _mediator.Send(request);

            return Ok(response);
        }

    }
}
