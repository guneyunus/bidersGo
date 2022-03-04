using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
using bidersGo.Domain.Entities;
using bidersGo.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using bidersGoUI.Extentions;
using DevExtreme.AspNet.Data;
using bidersGo.Application.Features.Commands.TeacherUpdate;
using bidersGo.Application.Features.Queries.TeacherGetAll;
using bidersGo.Application.Features.Commands.TeacherDelete;
using Newtonsoft.Json;

namespace bidersGoUI.Controllers
{
    public class TeacherController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public TeacherController(IMediator mediator, IUnitOfWork unitOfWork,UserManager<ApplicationUser> userManager)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            ClaimsPrincipal currentUser = this.User;
            
            var id = _userManager.GetUserId(currentUser);
            
            ViewBag.Id = id;
            return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> SetWorkingHours(string id)
        {
            //convert userId to TeacherId
            var Teacher = _unitOfWork.TeacherRepository.GetTeacherByUserId(id);
                TeacherWorkingWeekCreateCommandResponse model =
                await _mediator.Send(new TeacherWorkingWeekCreateCommandRequest(){Id =(Teacher.Id)});

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
        public IActionResult GetTeacher(DataSourceLoadOptions loadOptions)
        {
            var data = _unitOfWork.TeacherRepository.GetTeachersAll().ToList();
            return Ok(DataSourceLoader.Load(data, loadOptions));
        }

        public IActionResult Teachers()
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

        [HttpGet] public async Task<object> Get(DataSourceLoadOptions loadOptions,Guid id)
        {
            WorkingWeekOfHourInOneQueryResponse response = await _mediator.Send(new WorkingWeekOfHourInOneQueryRequest()
                {Id = id});
            var _data = response.WorkingHoursOfWeek.WorkingForOneHours;
            
            return DataSourceLoader.Load(_data, loadOptions);
        }

        [HttpPost]
        public IActionResult Post(string values,string id)
        {
            var newAppointment = new WorkingForOneHour();
            JsonConvert.PopulateObject(values, newAppointment);

            newAppointment.weekID = Guid.Parse(id);

            if (!TryValidateModel(newAppointment))
                return BadRequest();

            _unitOfWork.workingWeekRepository.WorkingHoursOfWeek(newAppointment.weekID).WorkingForOneHours.Add(newAppointment);
            _unitOfWork.SaveAsync();
            

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(string key, string values)
        {
           // var appointment = _data.Appointments.First(a => a.AppointmentId == key);
           var appointment = new WorkingForOneHour();
            JsonConvert.PopulateObject(values, appointment);

            appointment = _unitOfWork.workingWeekRepository.WorkingHoursOfWeek(appointment.weekID).WorkingForOneHours
                .FirstOrDefault(x => x.Id == Guid.Parse(key));

            if (!TryValidateModel(appointment))
                return BadRequest();

            _unitOfWork.SaveAsync();

            return Ok();
        }

        [HttpDelete]
        public void Delete(string key,Guid id)
        {
            var appointment = _unitOfWork.workingWeekRepository.WorkingHoursOfWeek(id).WorkingForOneHours
                .FirstOrDefault(x => x.Id == Guid.Parse(key));
            _unitOfWork.workingWeekRepository.WorkingHoursOfWeek(id).WorkingForOneHours.Remove(appointment);
            _unitOfWork.SaveAsync();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTeacher()
        {
            TeacherGetAllQueryResponse response = await _mediator.Send(new TeacherGetAllQueryRequest());
            ViewBag.Teacher = response.TeacherGetAll;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTeacher(TeacherUpdateCommandRequest request)
        {
            TeacherUpdateCommandResponse response = await _mediator.Send(request);

            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteTeacher()
        {
            TeacherGetAllQueryResponse response = await _mediator.Send(new TeacherGetAllQueryRequest());
            ViewBag.Ogretmenler = response.TeacherGetAll;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteTeacher(TeacherDeleteCommandRequest request)
        {
            TeacherDeleteCommandResponse response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
