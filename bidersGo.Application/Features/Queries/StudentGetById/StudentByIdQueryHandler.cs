using AutoMapper;
using bidersGo.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using bidersGo.Application.Interfaces.UnitOfWork;
using bidersGo.Domain.Entities;

namespace bidersGo.Application.Features.Queries.StudentGetById
{
    public class StudentByIdQueryHandler : IRequestHandler<StudentGetByIdQueryRequest, StudentByIdQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public StudentByIdQueryHandler(IMapper mapper,IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }
        public  Task<StudentByIdQueryResponse> Handle(StudentGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            Student student = _unitOfWork.StudentRepository.GetById(request.Guid);

            return Task.FromResult(_mapper.Map<Student, StudentByIdQueryResponse>(student));
        }
    }
}
