using bidersGoUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using bidersGo.Application.Features.Commands.AddressCreate;
using bidersGo.Application.Features.Queries.StudentGetById;
using MediatR;

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
        public IActionResult CreateAddress()
        {
            var model = new AddressCreateCommandRequest();
            return View(model);
        }

        [HttpPost]
        public async Task<AddressCreateCommandResponse> CreateAddress(AddressCreateCommandRequest request)
        {
            
            return await _mediator.Send(request);
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
