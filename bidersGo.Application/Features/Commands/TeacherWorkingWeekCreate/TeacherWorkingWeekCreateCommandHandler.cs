using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using bidersGo.Application.Interfaces.UnitOfWork;
using bidersGo.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace bidersGo.Application.Features.Commands.TeacherWorkingWeekCreate
{
    public class TeacherWorkingWeekCreateCommandHandler : IRequestHandler<TeacherWorkingWeekCreateCommandRequest,
        TeacherWorkingWeekCreateCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TeacherWorkingWeekCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<TeacherWorkingWeekCreateCommandResponse> Handle(TeacherWorkingWeekCreateCommandRequest request,
            CancellationToken cancellationToken)
        {
            var WorkingWeek =new WorkingHoursOfWeek();
            if (request.Id == null)
            {
                return null;
            }
            //hocanın calısma tablosu varsa o tabloyu dön
            var teacher = _unitOfWork.TeacherRepository.GetTeacherById(request.Id);
            if (teacher.WorkingHoursOfWeek.Count == 0)
            {
                WorkingWeek= new WorkingHoursOfWeek()
                {
                    Teacher = teacher,
                    TeacherId = teacher.Id,
                    WorkingForOneHours = new List<WorkingForOneHour>()
                };
               
                _unitOfWork.TeacherRepository.CreateWorkingForWeek(WorkingWeek);
                _unitOfWork.TeacherRepository.CreateWorkingWeekAddToTeacher(teacher.Id,WorkingWeek);
                
            }
            else
            {
                 WorkingWeek = teacher.WorkingHoursOfWeek[0];
            }
            
           
            var response = new TeacherWorkingWeekCreateCommandResponse()
            {
                Data = WorkingWeek,
                Message = "succes",
                Succeed = true
            };
            return Task.FromResult(response);
        }
    }
}