using bidersGo.Application.Features.Commands.StudentCreate;
using bidersGo.Application.Features.Commands.StudentDelete;
using bidersGo.Application.Features.Commands.StudenUpdate;
using bidersGo.Application.Features.Queries.StudentGetAll;
using bidersGo.Application.Features.Queries.StudentGetById;
using bidersGo.Application.Interfaces.UnitOfWork;
using bidersGoUI.Extentions;
using DevExtreme.AspNet.Data;
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
        private readonly IUnitOfWork _unitOfWork;
        public StudentController(IMediator mediator,IUnitOfWork unitOfWork)
        {
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
        public IActionResult GetStudent(DataSourceLoadOptions loadOptions)
        {
            var data = _unitOfWork.StudentRepository.GetStudentsAll();
            return Ok(DataSourceLoader.Load(data, loadOptions));
        }

        public IActionResult Students()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateStudent()
        {
            StudentGetAllQueryResponse response = await _mediator.Send(new StudentGetAllQueryRequest());
            ViewBag.Ogrenciler = response.StudentGetAll;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStudent(StudentUpdateCommandRequest request)
        {
            StudentUpdateCommandResponse response = await _mediator.Send(request);

            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteStudent()
        {
            StudentGetAllQueryResponse response = await _mediator.Send(new StudentGetAllQueryRequest());
            ViewBag.Student = response.StudentGetAll;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteStudent(StudentDeleteCommandRequest request)
        {
            StudentDeleteCommandResponse response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
