using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bidersGo.Application.Features.Commands.TeacherWorkingHoursCreate;
using bidersGo.Application.Features.Commands.TeacherWorkingWeekCreate;
using bidersGo.Application.Interfaces.UnitOfWork;
using MediatR;

namespace bidersGoUI.Controllers
{
    public class TeacherController : Controller
    {
        private readonly IMediator _meditor;
        private readonly IUnitOfWork _unitOfWork;

        public TeacherController(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _meditor = mediator;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> SetWorkingHours(string id)
        {
            //convert string to guid

            TeacherWorkingWeekCreateCommandResponse model =
                await _meditor.Send(new TeacherWorkingWeekCreateCommandRequest(){Id = Guid.Parse(id)});

            if (model == null)
            {
                return BadRequest();
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> SetWorkingOneHour(TeacherWorkingHoursCreateCommandRequest request)
        {
            TeacherWorkingHoursCreateCommandResponse response = await _meditor.Send(request);
            return Json(response);
        }

    }
}
