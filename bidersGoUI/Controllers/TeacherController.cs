using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bidersGo.Application.Features.Commands.TeacherWorkingHoursCreate;
using bidersGo.Application.Features.Commands.TeacherWorkingWeekCreate;
using bidersGo.Application.Interfaces.UnitOfWork;
using MediatR;
using bidersGo.Application.Features.Queries.TeacherGetByLesson;
using bidersGo.Application.Features.Queries.LessonGetAll;
using Microsoft.AspNetCore.Authorization;
using bidersGo.Application.Features.Commands.TeacherCreate;
using bidersGo.Application.Features.Queries.WorkingWeekForLesson;

namespace bidersGoUI.Controllers
{
    public class TeacherController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        public TeacherController(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
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
                await _mediator.Send(new TeacherWorkingWeekCreateCommandRequest(){Id = Guid.Parse(id)});

            if (model == null)
            {
                return BadRequest();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SetWorkingOneHour(TeacherWorkingHoursCreateCommandRequest request)
        {
            TeacherWorkingHoursCreateCommandResponse response = await _mediator.Send(request);
            return Json(response);
        }

        [HttpGet]
        public IActionResult GetTeacher()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetTeacherByLesson(string id)
        {

            Guid RequestGuid = Guid.Parse(id);
            TeacherGetByLessonQueryResponse response = await _mediator.Send(new TeacherGetByLessonQueryRequest() { LessonId = RequestGuid });


            return Json(response);
        }

        [HttpGet]
        public async Task<IActionResult> RegisterTeacher()
        {
            LessonGetAllQueryResponse response = await _mediator.Send(new LessonGetAllQueryRequest());
            ViewBag.Lessons = response.LessonGetAll;
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterTeacher(TeacherCreateCommandRequest request)
        {
            TeacherCreateCommandResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet]
        public async Task<JsonResult> GetHoursInWorkingTable(Guid id)
        {
            WorkingWeekOfHourInOneQueryResponse response = await _mediator.Send(new WorkingWeekOfHourInOneQueryRequest()
                {Id = id});
            
            return Json(response);
        }
    }
}
