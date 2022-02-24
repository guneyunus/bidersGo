using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using bidersGo.Application.Interfaces.Repositories;
using bidersGo.Application.Interfaces.UnitOfWork;
using bidersGo.Domain.Entities;
using MediatR;

namespace bidersGo.Application.Features.Commands.TeacherWorkingHoursCreate
{
    public class TeacherWorkingHoursCreateCommandHandle : IRequestHandler<TeacherWorkingHoursCreateCommandRequest, TeacherWorkingHoursCreateCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TeacherWorkingHoursCreateCommandHandle(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task<TeacherWorkingHoursCreateCommandResponse> Handle(TeacherWorkingHoursCreateCommandRequest request, CancellationToken cancellationToken)
        {
            var tablo = _unitOfWork.TeacherRepository.GetWorkingTable(request.Id);
            var teacher = _unitOfWork.TeacherRepository.GetTeacherByWorkingTableId(request.Id);

            tablo.WorkingForOneHours.Add(new WorkingForOneHour()
            {
                week = tablo,
                weekID = tablo.Id,
                WorkingStart = request.startDate,
                WorkingStop = request.endDate
            });
            _unitOfWork.Save();
            var response = new TeacherWorkingHoursCreateCommandResponse()
            {
                Message = "başarılı",
                Succeed = true
            };
            return Task.FromResult(response);
        }
    }
}
