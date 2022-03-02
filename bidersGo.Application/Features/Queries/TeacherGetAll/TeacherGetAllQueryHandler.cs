using AutoMapper;
using bidersGo.Application.Features.Queries.TeacherGetById;
using bidersGo.Application.Interfaces.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Queries.TeacherGetAll
{
    public class TeacherGetAllQueryHandler : IRequestHandler<TeacherGetAllQueryRequest, TeacherGetAllQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TeacherGetAllQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task<TeacherGetAllQueryResponse> Handle(TeacherGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            var teacher = _unitOfWork.TeacherRepository.GetTeachersAll();
            var model = new TeacherGetAllQueryResponse();
            foreach (var item in teacher)
            {
                model.TeacherGetAll.Add(_mapper.Map<TeacherGetByIdQueryResponse>(item));
            }
            return Task.FromResult(model);
        }
    }
}