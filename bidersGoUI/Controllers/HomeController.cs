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
using bidersGo.Application.Features.Commands.LessonUpdate;
using bidersGo.Application.Features.Queries.TeacherGetByLesson;

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
        public async Task<IActionResult> GetLessonAll()
        {
            LessonGetAllQueryResponse model = await _mediator.Send(new LessonGetAllQueryRequest());
            return View(model);
        }

       


    }
}
