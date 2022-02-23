using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using bidersGo.Application.Interfaces.Repositories;
using bidersGo.Application.Interfaces.UnitOfWork;
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
            throw new NotImplementedException();
        }
    }
}
