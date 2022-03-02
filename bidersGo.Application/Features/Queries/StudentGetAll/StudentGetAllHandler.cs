using AutoMapper;
using bidersGo.Application.Features.Queries.StudentGetById;
using bidersGo.Application.Interfaces.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Queries.StudentGetAll
{
    public class StudentGetAllHandler : IRequestHandler<StudentGetAllQueryRequest, StudentGetAllQueryResponse>
        
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StudentGetAllHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public Task<StudentGetAllQueryResponse> Handle(StudentGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            var student = _unitOfWork.StudentRepository.GetStudentsAll();
            var model = new StudentGetAllQueryResponse();
            foreach (var item in student)
            {
                model.StudentGetAll.Add(_mapper.Map<StudentByIdQueryResponse>(item));
            }
            return Task.FromResult(model);
        }
    }
}
