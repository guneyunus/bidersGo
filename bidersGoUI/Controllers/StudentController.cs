using bidersGo.Application.Features.Commands.StudentCreate;
using bidersGo.Application.Features.Queries.StudentGetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bidersGoUI.Controllers
{
    public class StudentController : Controller
    {
        private readonly IMediator _mediator;
        public StudentController(IMediator mediator)
        {
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
    }
}
