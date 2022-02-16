using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using bidersGo.Application.Interfaces.UnitOfWork;
using bidersGo.Domain.Entities;
using MediatR;

namespace bidersGo.Application.Features.Commands.MeetCreate
{
    public class MeetCreateCommandHandler : IRequestHandler<MeetCreateCommandRequest, MeetCreateCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MeetCreateCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task<MeetCreateCommandResponse> Handle(MeetCreateCommandRequest request, CancellationToken cancellationToken)
        {
            var teacher = _unitOfWork.TeacherRepository.GetTeacherById(request.TeacherGuid);
            var student = _unitOfWork.StudentRepository.GetStudentById(request.StudentGuid);
            var address = request.Address;
            DateTime lessonStartTime = request.LessonTime;
            DateTime lessonFinishTime = request.LessonFinishTime;

            var price = (decimal)(lessonFinishTime.Hour - lessonStartTime.Hour) * 100;

            var meet = new Meet()
            {
                Address = address,
                LessonTime = lessonStartTime,
                LessonFinishTime = lessonFinishTime,
                IsApproved = false,
                Price = price,
                Student = student,
                StudentId = student.Id,
                Teacher = teacher,
                TeacherId = teacher.Id
            };

            _unitOfWork.MeetRepository.Create(meet);
            _unitOfWork.Save();

            var model = new MeetCreateCommandResponse();
            model.Succeed = true;
            if (model.Succeed == true)
            {
                model.Message = "Meet başarı ile kaydedildi";
            }
            else
            {
                model.Message = "Meet kaydı başarısız";
            }

            return Task<MeetCreateCommandResponse>.FromResult(model);


        }
    }
}
