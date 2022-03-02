using bidersGo.Application.Features.Commands.LessonCreate;
using bidersGo.Application.Features.Commands.LessonDelete;
using bidersGo.Application.Features.Commands.LessonUpdate;
using bidersGo.Application.Features.Queries.LessonGetAll;
using bidersGo.Application.Features.Queries.LessonGetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace bidersGoUI.Controllers
{
    public class LessonController : Controller
    {
        private readonly IMediator _mediator;
        public LessonController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateLesson()
        {
            LessonGetAllQueryResponse response = await _mediator.Send(new LessonGetAllQueryRequest());
            ViewBag.Dersler = response.LessonGetAll;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateLesson(LessonUpdateCommandRequest request)
        {
            LessonUpdateCommandResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet]
        public IActionResult CreateLesson()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateLesson(LessonCreateCommandRequest request)
        {
            LessonCreateCommandResponse response = await _mediator.Send(request);

            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetLesson()
        {
            LessonGetAllQueryResponse response = await _mediator.Send(new LessonGetAllQueryRequest());

            return View(response);
        }

        [HttpGet()]
        public async Task<IActionResult> GetLessonById(Guid id)
        {
            LessonGetByIdQueryResponse response = await _mediator.Send(new LessonGetByIdQueryRequest() { Guid = id });

            return View(response);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteLesson()
        {
            LessonGetAllQueryResponse response = await _mediator.Send(new LessonGetAllQueryRequest());
            ViewBag.Lesson = response.LessonGetAll;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteLesson(LessonDeleteCommandRequest request)
        {
            LessonDeleteCommandResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetLessonAll()
        //{
        //    LessonGetAllQueryResponse model = await _mediator.Send(new LessonGetAllQueryRequest());
        //    return View(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> GetLessonAll(LessonGetAllQueryResponse model)
        //{
        //    return null;
        //}
    }
}
