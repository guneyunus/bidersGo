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

namespace bidersGoUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IMediator _mediator;
        public HomeController(ILogger<HomeController> logger,IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
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
    }
}
