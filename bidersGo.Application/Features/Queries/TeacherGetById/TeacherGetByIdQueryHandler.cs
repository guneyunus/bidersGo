using AutoMapper;
using bidersGo.Application.Interfaces.Repositories;
using bidersGo.Application.Interfaces.UnitOfWork;
using bidersGo.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Queries.TeacherGetById
{
    public class TeacherGetByIdQueryHandler :
        IRequestHandler<TeacherGetByIdQueryRequest,TeacherGetByIdQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TeacherGetByIdQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
             _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<TeacherGetByIdQueryResponse> Handle(TeacherGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var teacher = _unitOfWork.TeacherRepository.GetTeacherById(request.Guid);

            TeacherGetByIdQueryResponse model = _mapper.Map<TeacherGetByIdQueryResponse>(teacher);
            return  Task<TeacherGetByIdQueryResponse>.FromResult(model);
        }
    }
}
