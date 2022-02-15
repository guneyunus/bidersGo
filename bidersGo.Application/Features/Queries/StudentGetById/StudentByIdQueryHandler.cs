using AutoMapper;
using bidersGo.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using bidersGo.Domain.Entities;

namespace bidersGo.Application.Features.Queries.StudentGetById
{
    public class StudentByIdQueryHandler : IRequestHandler<StudentGetByIdQueryRequest, StudentByIdQueryResponse>
    {
        private readonly IStudentRepository _studentRepository;
        IMapper _mapper;

        public StudentByIdQueryHandler(IMapper mapper,IStudentRepository studentRepository)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;

        }
        public async Task<StudentByIdQueryResponse> Handle(StudentGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            Student student = await _studentRepository.GetById(request.Guid);

            return _mapper.Map<Student, StudentByIdQueryResponse>(student);
        }
    }
}
