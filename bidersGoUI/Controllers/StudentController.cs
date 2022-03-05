using bidersGo.Application.Features.Commands.StudentCreate;
using bidersGo.Application.Features.Commands.StudentDelete;
using bidersGo.Application.Features.Commands.StudenUpdate;
using bidersGo.Application.Features.Queries.StudentGetAll;
using bidersGo.Application.Features.Queries.StudentGetById;
using bidersGo.Application.Interfaces.UnitOfWork;
using bidersGo.Domain.Entities.Identity;
using bidersGoUI.Extentions;
using DevExtreme.AspNet.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace bidersGoUI.Controllers
{
    
    public class StudentController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        public StudentController(IMediator mediator,IUnitOfWork unitOfWork,UserManager<ApplicationUser> userManager)
        {
              _mediator = mediator;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            ClaimsPrincipal currentUser = this.User;
            var id = _userManager.GetUserId(currentUser);
            var studentId = _unitOfWork.StudentRepository.GetStudentByUserId(id);
            
            StudentByIdQueryResponse response = await _mediator.Send(new StudentGetByIdQueryRequest()
                {Guid = studentId.Id});

            return View(response);
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
