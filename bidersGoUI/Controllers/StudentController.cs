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
using bidersGo.Application.Features.Queries.LessonGetAll;
using bidersGo.Application.Features.Queries.WorkingWeekForLesson;
using bidersGo.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

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


        [HttpGet]
        public async Task<IActionResult> GetLessonAll()
        {
            LessonGetAllQueryResponse model = await _mediator.Send(new LessonGetAllQueryRequest());
            return View(model);
        }


        [HttpPost] 
        public IActionResult GetMeetScheduler(Guid id)
        {
            ViewBag.TeacherId = id;
            return View();
        }

        [HttpGet]
        public async Task<object> Get(DataSourceLoadOptions loadOptions, Guid id)
        {
            //hocanın calışma tablosu id'si tespiti

            var tabloId = _unitOfWork.workingWeekRepository.HocaTablosu(id);

            WorkingWeekOfHourInOneQueryResponse response = await _mediator.Send(new WorkingWeekOfHourInOneQueryRequest()
                { Id = tabloId.Id });

            var GetDataList = new List<WorkingForOneHour>();
            foreach (var workingForOneHour in response.WorkingHoursOfWeek.WorkingForOneHours)
            {
                var data = new WorkingForOneHour();
                data.Id = workingForOneHour.Id;
                data.StartDate = workingForOneHour.StartDate;
                data.EndDate = workingForOneHour.EndDate;
                data.AllDay = workingForOneHour.AllDay;
                data.weekID = workingForOneHour.weekID;
                data.Description = workingForOneHour.Description;
                data.RecurrenceException = workingForOneHour.RecurrenceException;
                data.RecurrenceRule = workingForOneHour.RecurrenceRule;
                data.Text = workingForOneHour.Text;
                data.isDisabled = true;
                GetDataList.Add(data);
            }
            
            return DataSourceLoader.Load(GetDataList, loadOptions);
        }

        [HttpPut]
        public IActionResult Put(string key, string values)
        {
            var appointment = new WorkingForOneHour();
            JsonConvert.PopulateObject(values, appointment);

            //appointment.weekID = Guid.Parse(key);
            _unitOfWork.workingWeekRepository.UpdateAppointment(appointment);
            
            ClaimsPrincipal currentUser = this.User;
            var id = _userManager.GetUserId(currentUser);
            var studentId = _unitOfWork.StudentRepository.GetStudentByUserId(id);

            var teacher = _unitOfWork.TeacherRepository.GetTeacherByWorkingTableId(appointment.weekID);

            var meet = new Meet()
            {
                IsApproved = false,
                StudentId = studentId.Id,
                TeacherId = teacher.Id,
                LessonTime = DateTime.Parse(appointment.StartDate),
                LessonFinishTime = DateTime.Parse(appointment.EndDate),
                
            };
            meet.Price = 100;
            
            

            //weekid'den hocaya ulaş 
            //meet oluştur 


            if (!TryValidateModel(appointment))
                return BadRequest();

            return Ok();
        }
    }
}
