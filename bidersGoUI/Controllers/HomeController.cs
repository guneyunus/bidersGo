using bidersGoUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using bidersGo.Application.Features.Commands.AddressCreate;
using bidersGo.Application.Features.Queries.AddressGetAll;
using bidersGo.Application.Features.Queries.StudentGetById;
using MediatR;
using bidersGo.Application.Features.Queries.LessonGetAll;
using bidersGo.Application.Features.Queries.LessonGetById;
using Microsoft.AspNetCore.Authorization;
using bidersGo.Application.Features.Commands.TeacherCreate;
using Microsoft.AspNetCore.Identity;
using bidersGo.Application.Interfaces.UnitOfWork;
using bidersGo.Application.Features.Commands.LessonCreate;
using bidersGo.Application.Features.Commands.ModeratorCreate;
using bidersGo.Application.Features.Commands.StudentCreate;

namespace bidersGoUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(ILogger<HomeController> logger,IMediator mediator,IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        
        public IActionResult Index()
        {

            return View();
        }

        [HttpGet("{Id}")]
        public async Task<StudentByIdQueryResponse> StudentDetay([FromQuery] StudentGetByIdQueryRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("{Id}")]
        public async Task<StudentByIdQueryResponse> StudentDetayOne([FromQuery] StudentGetByIdQueryRequest request)
        {
            return await _mediator.Send(request);
        }



        [HttpGet]
        public async Task<IActionResult> GetAdress()
        {
            
            AddressGetAllQueryResponse response = await _mediator.Send(new AddressGetAllQueryRequest());

            return View(response);
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
           LessonGetByIdQueryResponse response = await _mediator.Send(new LessonGetByIdQueryRequest() { Guid=id});

            return View(response);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult GetTeacher()
        {
            return View();
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
        public IActionResult RegisterStudent()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterStudent(StudentCreateCommandRequest request)
        {
            StudentCreateCommandResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet]
        public IActionResult CreateLesson()
        {
            return View();
        }

        public async Task<IActionResult> CreateLesson(LessonCreateCommandRequest request)
        {
            LessonCreateCommandResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet]
        public IActionResult RegisterModerator()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterModerator(ModeratorCreateCommandRequest request)
        {
            ModeratorCreateCommandResponse response= await _mediator.Send(request);

            return Ok(response);
        }
    }
}
